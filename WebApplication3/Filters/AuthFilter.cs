using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApplication3.Controllers;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Filters
{
    public class AuthFilter : ActionFilterAttribute
    {
        ISessionManagerService sessionstockage;
        private string role;
        string filepath = Path.Combine("TextFile", "Users.txt");
        public AuthFilter(ISessionManagerService sessionstockage)
        {
            this.sessionstockage = sessionstockage;
            
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var data = context.HttpContext.Session.GetString("role");
            if ( data != "admin")
            {
                context.Result = new ContentResult
                {
                    Content = "Access denied: Admins only."
                };
                context.HttpContext.Response.Redirect("/Todos/Index");

            }
            
        }
    }
}
