using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;

namespace DF.Web.Filters
{
    /// <summary>
    ///     Handles the Global exceptions -- Logged them and format the API response
    /// </summary>
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        /// <summary>
        ///     On Exception log it and format the error message
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var message = actionExecutedContext.Exception;
            var httpError = new HttpError(string.Format("{0}- Details: {1}", message.Message, message.InnerException != null ? message.InnerException.Message : ""));
            var errorResponse = actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, httpError);
            throw new HttpResponseException(errorResponse);
        }
    }
}