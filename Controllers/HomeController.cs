using WebPetShop.Models;
using WebPetShop.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace WebPetShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService_API _service;

        public HomeController(IService_API service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var productos = await _service.GetProductosAsync();
            return View(productos);
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
    }
}