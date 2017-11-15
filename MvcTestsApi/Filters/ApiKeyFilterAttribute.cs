using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace MvcTestsApi.Filters
{
    public class ApiKeyFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.Request.Headers.Contains("x-apikey") ||
                actionContext.Request.Headers.GetValues("x-apikey").Single() != "4835d7e2-5ef5-4fdb-a0a4-023535028308")
            {
                actionContext.Response =
                    new HttpResponseMessage(HttpStatusCode.Unauthorized) { Content = new StringContent("Invalid value for x-apikey") };

                return;
            }

            base.OnActionExecuting(actionContext);
        }
    }
}
