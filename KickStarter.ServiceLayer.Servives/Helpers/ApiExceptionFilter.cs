using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace KickStarter.ServiceLayer.Helpers
{
    public class ApiExceptionFilter : ExceptionFilterAttribute, IExceptionFilter
    {
        private readonly ILogger<ApiExceptionFilter> Logger;

        public ApiExceptionFilter(ILogger<ApiExceptionFilter> logger)
        {
            Logger = logger;
        }

        /// <summary>
        ///     Catches the exceptions from api requests
        /// </summary>
        public override void OnException(ExceptionContext context)
        {
            Logger.LogError(Utils.GetErrorMessage(context.Exception));

            var jsonResult = new JsonResult(new {error = context.Exception.Message});
            jsonResult.StatusCode = (int) HttpStatusCode.InternalServerError;
            context.Result = jsonResult;
        }
    }
}