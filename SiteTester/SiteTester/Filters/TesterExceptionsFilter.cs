using System.Net;
using System.Net.NetworkInformation;

using Microsoft.Data.SqlClient;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SiteTester.Filters
{
    public class TesterExceptionsFilter: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if(context.Exception is PingException)
            {
                context.Result = new ContentResult { Content="Wrong Url or site doesn`t exist." };
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.ExceptionHandled = true;
            }
            else if(context.Exception is SqlException)
            {
                context.Result = new ContentResult { Content = "Oops... Error while working with database." };
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.ExceptionHandled = true;
            }
        }
    }
}
