using AggriPortal.API.Contracts.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace  AggriPortal.API.Helper.Validation
{
    public class ValidationErrorResult : IActionResult
    {
     
        public async Task ExecuteResultAsync(ActionContext context)
        {
            var modelState = context.ModelState;
            var modelStateEntries = context.ModelState.Where(e => e.Value.Errors.Count > 0).ToArray();
            var errors = new List<ValidationError>();

            if (modelState != null && modelState.Any(e => e.Value.Errors.Count > 0))
            {
                errors = modelState.Keys.SelectMany(key => modelState[key].Errors
                                            .Select(err => new ValidationError { Name = key, Description = err.ErrorMessage })).ToList();
            }

            var responseResult = new BaseResponse()
            {
                IsSuccess = false,
                StatusCode= 400,
                ResponseMessage =  "يرجي التحقق من البيانات أدناه",
                ValidationErrors = errors
            };
            
            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int) System.Net.HttpStatusCode.BadRequest;
            var result = JsonSerializer.Serialize(responseResult, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase } );
            await context.HttpContext.Response.WriteAsync(result).ConfigureAwait(false);
        }
    }
}
