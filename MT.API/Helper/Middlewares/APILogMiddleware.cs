using AggriPortal.API.Contracts.Response;
using AggriPortal.API.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace  AggriPortal.API.Helper.Middlewares
{
    public class APILogMiddleware
    {
        private readonly RequestDelegate next;
        private ILogger<APILogMiddleware> _logger;
        public APILogMiddleware(RequestDelegate next, ILogger<APILogMiddleware> logger)
        {
            this.next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            // Get the incoming request
            var request = await FormatRequest(context.Request);

            // before
            var originalBodyStream = context.Response.Body;

            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;

                try
                {
                    await next(context);

                    if (context.Response.StatusCode == (int)HttpStatusCode.OK)
                    {
                        var body = await FormatResponse(context.Response);
                    }
                    else
                    {
                        await HandleNotSuccessRequestAsync(context, context.Response.StatusCode);
                    }
                        
                    //await HandleSuccessRequestAsync(context, body, context.Response.StatusCode);
                }
                catch (System.Exception ex)
                {
                    await HandleExceptionAsync(context, ex);
                }
                finally
                {
                    await responseBody.CopyToAsync(originalBodyStream);
                }
            }
            //await next(context);
            
            // after.
        }

        private async Task<string> FormatRequest(HttpRequest request)
        {
            var body = request.Body;

            //This line allows us to set the reader for the request back at the beginning of its stream.
            request.EnableBuffering();

            //We now need to read the request stream.  First, we create a new byte[] with the same length as the request stream...
            var buffer = new byte[Convert.ToInt32(request.ContentLength)];

            //...Then we copy the entire request stream into the new buffer.
            await request.Body.ReadAsync(buffer, 0, buffer.Length);

            //We convert the byte[] into a string using UTF8 encoding...
            var bodyAsText = Encoding.UTF8.GetString(buffer);

            //..and finally, assign the read body back to the request body, which is allowed because of EnableRewind()
            request.Body = body;
            _logger.LogInformation($"{request.Scheme} {request.Host}{request.Path} {request.QueryString} {bodyAsText}");
            return $"{request.Scheme} {request.Host}{request.Path} {request.QueryString} {bodyAsText}";
        }

        private async Task<string> FormatResponse(HttpResponse response)
        {
            //We need to read the response stream from the beginning...
            response.Body.Seek(0, SeekOrigin.Begin);

            //...and copy it into a string
            string text = await new StreamReader(response.Body).ReadToEndAsync();

            //We need to reset the reader for the response so that the client can read it.
            response.Body.Seek(0, SeekOrigin.Begin);

            //Return the string for the response, including the status code (e.g. 200, 404, 401, etc.)
            _logger.LogInformation($"{response.StatusCode}: {text}");
            return $"{response.StatusCode}: {text}";
        }

        private static Task HandleNotSuccessRequestAsync(HttpContext context, int code)
        {
            context.Response.ContentType = "application/json";

            BaseResponse apiResponse = null;

            if (code == (int)HttpStatusCode.NotFound)
                apiResponse = new BaseResponse(false,code,"The specified URI does not exist. Please verify and try again.");
            else if (code == 401)
            {
                apiResponse = new BaseResponse(false, (int)HttpStatusCode.Unauthorized, "401 Unauthrized, access denied.");
            }
            else if (code == (int)HttpStatusCode.NoContent)
                apiResponse = new BaseResponse(false,code,"The specified URI does not contain any content.");
            else
                apiResponse = new BaseResponse(false,500, "Your request cannot be processed. Please contact a support.");
            context.Response.StatusCode = code;
            var json = JsonConvert.SerializeObject(apiResponse);
            return context.Response.WriteAsync(json);
        }
        private static Task HandleExceptionAsync(HttpContext context, System.Exception exception)
        {
            BaseResponse baseResponse = null;
            if (exception is UnauthorizedAccessException)
            {
                baseResponse = new BaseResponse(false, (int)HttpStatusCode.Unauthorized, "401 Unauthrized, access denied.");
            }else if (exception is BadHttpRequestException badHttpRequestException)
            {
                baseResponse = new BaseResponse(false, (int)typeof(BadHttpRequestException).GetProperty("StatusCode", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(badHttpRequestException), "Invalid request");
            }
            else
            {
            #if !DEBUG
                var msg = "An unhandled error occurred.";  
                string stack = null;  
            #else
                var msg = exception.GetBaseException().Message;
                string stack = exception.StackTrace;
            #endif

                baseResponse = new BaseResponse(false, (int)HttpStatusCode.InternalServerError, msg);
            }
            context.Response.StatusCode = baseResponse.StatusCode;
            context.Response.ContentType = "application/json";

            return context.Response.WriteJson(baseResponse);
        }
        //private async Task<string> FormatResponse(HttpResponse response)
        //{
        //    response.Body.Seek(0, SeekOrigin.Begin);
        //    var plainBodyText = await new StreamReader(response.Body).ReadToEndAsync();
        //    response.Body.Seek(0, SeekOrigin.Begin);

        //    return plainBodyText;
        //}
        private bool IsSwagger(HttpContext context)
        {
            return context.Request.Path.StartsWithSegments("/swagger");
        }


    }

    public static class APILogMiddlewareExtension
    {
        public static IApplicationBuilder UseAPILogMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<APILogMiddleware>();
        }
    }
}
