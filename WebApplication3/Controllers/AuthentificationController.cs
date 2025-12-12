using Elfie.Serialization;
using Microsoft.AspNetCore.Mvc;
using System.IO;
 // Add this using directive at the top if not present
using System.Linq;
using WebApplication3.Filters;
using WebApplication3.Mapper;
using WebApplication3.Models;
using WebApplication3.Services;
using WebApplication3.ViewModels;

namespace WebApplication3.Controllers
{
    public class AuthentificationController : Controller
    {
        private string filePath = Path.Combine("TextFile", "Users.txt");
        ISessionManagerService sessionstockage;
        public AuthentificationController(ISessionManagerService sessionstockage)
        {
            this.sessionstockage = sessionstockage;
        }
        public IActionResult Inscrire()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Inscrire(InscrireVM vm)
        {
            string filePath = Path.Combine("TextFile", "Users.txt");
            if (!ModelState.IsValid)
            {
                return View();
            }
            User user = UserMapper.GetUserFromInscrire(vm);
            if (user == null)
            { 
                return View();
            }
            var users = System.IO.File.ReadAllLines(filePath);
            if (users.Any(u => u.Split('|')[0] == user.login))
            {
                return View();
            }
            System.IO.File.AppendAllText(filePath, $"\n{user.login}|{user.password}|{"user"}\n");
            return RedirectToAction(nameof(Login));
        }
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        [ServiceFilter(typeof(LogFilter))]
        public IActionResult Login(InscrireVM vm)
        {
            string role;
            string user;
            if (!ModelState.IsValid)
            {
                return View();
            }
            var users = System.IO.File.ReadAllLines(filePath);
            foreach (var u in users)
            {
                var p = u.Split("|");
                if (p[0] == vm.login && p[1] == vm.password)
                {
                    role = p[2];
                    user = p[0];
                    HttpContext.Session.SetString("role", role);
                    HttpContext.Session.SetString("user", user);
                    return RedirectToAction("Index", "Todos");
                }
            }
            return RedirectToAction("login");
        }
    }
}
