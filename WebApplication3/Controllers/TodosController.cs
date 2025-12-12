using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApplication3.Filters;
using WebApplication3.Models;
using WebApplication3.Service;
using WebApplication3.Services;
using WebApplication3.ViewModels;

namespace WebApplication3.Controllers
{
    public class TodosController : Controller
    {
        ISessionManagerService sessionstockage;
        public TodosController(ISessionManagerService sessionstockage)
        {
            this.sessionstockage = sessionstockage;
        }


        [ThemeFilter]
        [ServiceFilter(typeof(LogFilter))]
        public IActionResult Index()
        {
            List<Todo> List = sessionstockage.Get<List<Todo>>("Todos", HttpContext);
            return View(List);
        }
        [ServiceFilter(typeof(AuthFilter))]
        public IActionResult add()
        {
            return View();
        }
        [HttpPost]
        [ServiceFilter(typeof(LogFilter))]
        public IActionResult add(TodoaddVm vm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            List<Todo> list;
            //transformer les donnes en objet todo
            if (HttpContext.Session.GetString("Todos") == null)
            {
                list = new List<Todo>();
            }
            else
            {
                // Optionally, deserialize existing session data here if needed
                list = JsonSerializer.Deserialize<List<Todo>>(HttpContext.Session.GetString("Todos"));
            }
            Todo todo = TodoMappers.GetTodoFromTodo(vm);

            list.Add(todo);

            //session
            sessionstockage.add("Todos", list, HttpContext);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult SetTheme(string theme)
        {
            CookieOptions options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(30)
            };

            Response.Cookies.Append("theme", theme, options);

            return RedirectToAction("Index");
        }

    }
}
