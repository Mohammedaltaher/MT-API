using AggriPortal.API.Contracts.Response;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.Extensions.Hosting;
using System;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

namespace  AggriPortal.API.Extensions
{
    public class JsonExceptionMiddleware
    {
        private readonly IWebHostEnvironment _environment;
        private const string DefaultErrorMessage = "A server error occurred.";

        public JsonExceptionMiddleware(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            //httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var errFeature = httpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = errFeature.Error;

            if (exception == null)
            {
                return;
            }

            var error = new BaseResponse();

            if (_environment.IsDevelopment())
            {
                error.IsSuccess = false;
                error.StatusCode = (int)HttpStatusCode.InternalServerError;
                error.ResponseMessage = exception.StackTrace;
            }
            else
            {
                if (exception is BadHttpRequestException badHttpRequestException)
                {
                    error.IsSuccess = false;
                    error.StatusCode = (int)typeof(BadHttpRequestException).GetProperty("StatusCode", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(badHttpRequestException);
                    error.ResponseMessage = "Invalid request";
                }
                else if (exception.GetType() == typeof(UnauthorizedAccessException))
                {
                    error.IsSuccess = false;
                    error.StatusCode = 401;
                    error.ResponseMessage = "401 Unauthrized, access denied.";
                }
                else
                {
                    error.IsSuccess = false;
                    error.StatusCode = 500;
                    error.ResponseMessage = "An unexpected error occurred!";
                }

                /// Save error.
            }

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = error.StatusCode;
            await httpContext.Response.WriteJson(error, "application/problem+json");
        }
    }
}
