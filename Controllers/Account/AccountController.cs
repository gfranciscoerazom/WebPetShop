using WebPetShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebPetShop.Models.ViewModel;
using WebPetShop.Services;

namespace WebPetShop.Controllers.Account
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index_Login()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [HttpPost]
        public IActionResult Login(LoginSignUpViewModel model)
        {
            // Realizar la validación del usuario y la contraseña
            if (IsValidUser(model.Username, model.Password))
            {
                // Verificar el tipo de usuario (admin o cliente)
                bool isAdmin = CheckIfUserIsAdmin(model.Username);

                if (isAdmin)
                {
                    // Redireccionar a la página de administrador
                    return RedirectToAction("Index_Admin", "Admin");
                }
                else
                {
                    // Redireccionar a la página de cliente
                    return RedirectToAction("Index_Cliente", "Cliente");
                }
            }
            else
            {
                // Si las credenciales son inválidas, mostrar mensaje de error
                ModelState.AddModelError("", "Credenciales inválidas");
                return View(model);
            }
        }

        private bool IsValidUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        private bool CheckIfUserIsAdmin(string username)
        {
            throw new NotImplementedException();
        }

        //Validar login con index con parametros al modelo de cliente
        public IActionResult Login(Cliente model)
        {
            //Validar si el usuario es admin, es cliente o no existe
            if (model.Email == Request.Form["Username"] && model.Contrasena == Request.Form["Password"])
            {
                string usuario = Request.Form["Username"];
                System.Console.WriteLine(usuario);

                if(model.Email.Equals(usuario) == model.IsAdmin)
                {
                    return RedirectToAction("Index_Admin", "Home/Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Home/Cliente");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account"); //Pagina de error
            }
        }

    }
}