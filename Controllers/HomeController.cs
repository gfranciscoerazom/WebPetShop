using WebPetShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace WebPetShop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
  
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login(Cliente model)
        {
            if (model.Email == "juan@gmail.com" && model.Contrasena == "12345")
            {
                return RedirectToAction("Index_Admin", "Admin");
            }
            else if (model.Email == "maria@gmail.com" && model.Contrasena == "12345")
            {
                return RedirectToAction("Index_Admin", "Admin");
            }
            else
            {
                return RedirectToAction("Index", "Cliente");
            }

        }
    }
}