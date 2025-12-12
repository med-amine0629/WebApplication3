using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication3.Filters
{
    public class LogFilter :ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            string controller = context.RouteData.Values["controller"]?.ToString();
            string action = context.RouteData.Values["action"]?.ToString();
            string user = context.HttpContext.Session.GetString("user");
            string filepath = Path.Combine("TextFile", "Log.txt");
            string log = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {user} - {controller} - {action}\n";
            File.AppendAllText(filepath, log);

        }
    }
}
