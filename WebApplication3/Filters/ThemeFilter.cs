using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication3.Filters
{
    public class ThemeFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var http = context.HttpContext;
            string theme = http.Request.Cookies["theme"] ?? "light";

            // Si pas de cookie, définir un theme par défaut
            if (string.IsNullOrEmpty(theme))
                theme = "light";

            // Envoyer vers la vue
            var controller = context.Controller as Controller;
            if (controller != null)
            {
                controller.ViewData["theme"] = theme;
            }

            base.OnActionExecuting(context);
        }

    }
}
