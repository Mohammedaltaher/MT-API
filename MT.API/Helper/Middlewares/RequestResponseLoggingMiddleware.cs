using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.IO;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using AggriPortal.API.Persistence;
using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Helper.Middlewares
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly RecyclableMemoryStreamManager _recyclableMemoryStreamManager;
        private readonly IWebHostEnvironment _environment;
        private APILogHistory apiLogModel;
        public RequestResponseLoggingMiddleware(RequestDelegate next,ILoggerFactory loggerFactory, IWebHostEnvironment environment)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestResponseLoggingMiddleware>();
            _recyclableMemoryStreamManager = new RecyclableMemoryStreamManager();
            _environment = environment;
            apiLogModel = new APILogHistory();
        }

        public async Task Invoke(HttpContext context, IUnitOfWork unitOfWork)
        {
            
                //code dealing with the request

                //await _next(context);
                await LogRequest(context);
                await LogResponse(context, unitOfWork);
            //code dealing with the response
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private async Task LogRequest(HttpContext context) 
        {
            context.Request.EnableBuffering();

            await using var requestStream = _recyclableMemoryStreamManager.GetStream();
            await context.Request.Body.CopyToAsync(requestStream);
            apiLogModel = new APILogHistory()
            {
                Id = Guid.NewGuid(),
                Method = context.Request.Method,
                Schema = context.Request.Scheme,
                Host = context.Request.Host.ToString(),
                Path = context.Request.Path,
                QueryString = context.Request.QueryString.ToString(),
                RequestBody = ReadStreamInChunks(requestStream)
            };
            
            //_logger.LogInformation($"Http Request Information:{Environment.NewLine}" +
            //                       $"Method:{context.Request.Method} " +
            //                       $"Schema:{context.Request.Scheme} " +
            //                       $"Host: {context.Request.Host} " +
            //                       $"Path: {context.Request.Path} " +
            //                       $"QueryString: {context.Request.QueryString} " +
            //                       $"Request Body: {ReadStreamInChunks(requestStream)}");
            context.Request.Body.Position = 0;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private static string ReadStreamInChunks(Stream stream)
        {
            const int readChunkBufferLength = 4096;

            stream.Seek(0, SeekOrigin.Begin);

            using var textWriter = new StringWriter();
            using var reader = new StreamReader(stream);

            var readChunk = new char[readChunkBufferLength];
            int readChunkLength;

            do
            {
                readChunkLength = reader.ReadBlock(readChunk, 0,readChunkBufferLength);
                textWriter.Write(readChunk, 0, readChunkLength);
            } while (readChunkLength > 0);

            return textWriter.ToString();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private async Task LogResponse(HttpContext context, IUnitOfWork unitOfWork)
        {
            var originalBodyStream = context.Response.Body;
            await using var responseBody = _recyclableMemoryStreamManager.GetStream();
            context.Response.Body = responseBody;

             await _next(context);
            
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var text = await new StreamReader(context.Response.Body).ReadToEndAsync();
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            apiLogModel.ResponseBody = text;
            apiLogModel.StatusCode = context.Response.StatusCode;
            //apiLogModel.CreatedBy = context.GetUserId();
            if (!IsSwagger(context) && apiLogModel.StatusCode != (int)HttpStatusCode.OK)
            {
                await unitOfWork.APILogHistory.AddAsync(apiLogModel);
                await unitOfWork.Commit();
            }

            await responseBody.CopyToAsync(originalBodyStream);
        }

        private bool IsSwagger(HttpContext context)
        {
            return context.Request.Path.StartsWithSegments("/swagger");
        }

        //private Task HandleNonSuccessRequestAsync(HttpContext context)
        //{
        //    int statusCode = context.Response.StatusCode;
        //    BaseResponse error = new BaseResponse(false, statusCode, GetStatusCodeErrorMessage(statusCode));
        //    context.Response.ContentType = "application/json";
        //    context.Response.StatusCode = statusCode;
        //    var result = JsonSerializer.Serialize(error, new JsonSerializerOptions { PropertyNamingRoles = JsonNamingPolicy.CamelCase });
        //    return context.Response.WriteAsync(result);
        //}

        //private Task HandleExceptionAsync(HttpContext context, Exception exception)
        //{
        //    string err = _environment.IsDevelopment() ? exception.StackTrace : "An unexpected error occurred!";
        //    var response = new BaseResponse(false, (int)context.Response.StatusCode, err);
        //    var result = JsonSerializer.Serialize(response, new JsonSerializerOptions { PropertyNamingRoles = JsonNamingPolicy.CamelCase });
        //    context.Response.ContentType = "application/json";
        //    return context.Response.WriteAsync(result);
        //}

        //private string GetStatusCodeErrorMessage(int statusCode)
        //{
        //    switch (statusCode)
        //    {
        //        case (int)HttpStatusCode.Unauthorized:
        //            return "غير مصرح";
        //        case (int)HttpStatusCode.NotFound:
        //            return "غير موجود";
        //        case (int)HttpStatusCode.InternalServerError:
        //            return "Error 500";
        //        default:
        //            return "Defualt Error";
        //    }
        //}
    }

    /// <summary>
    /// Extension method used to add the middleware to the HTTP request pipeline.
    /// </summary>
    public static class RequestResponseLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestResponseLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestResponseLoggingMiddleware>();
        }
    }


}
