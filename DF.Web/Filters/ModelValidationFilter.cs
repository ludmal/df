using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace DF.Web.Filters
{
    /// <summary>
    /// Handles the Modal errors globally
    /// </summary>
    public class ModelValidationFilter : ActionFilterAttribute
    {
        //Return the 200 OK status code for Model errors
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ModelState.IsValid == false)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest, actionContext.ModelState);
            }
        }

    }
}