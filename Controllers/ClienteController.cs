using WebPetShop.Models;
using WebPetShop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;

namespace WebPetShop.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IService_API _service;

        public ClienteController(IService_API service)
        {
            _service = service;
        }

        public async Task<ActionResult> Index()
        {
            var clientes = await _service.GetClientesAsync();

            return View(clientes);
        }

        public async Task<ActionResult> Cliente(int idCliente)
        {
            var cliente = new Cliente();

            ViewBag.Action = "Add";

            if (idCliente != 0)
            {
                cliente = await _service.GetClienteAsync(idCliente);
                ViewBag.Action = "Edit";
            }

            return View(cliente);
        }

        [HttpPost]
        public async Task<ActionResult> Save(Cliente cliente)
        {
            bool response;

            if (cliente.ClienteId == 0)
            {
                response = await _service.AddClienteAsync(cliente);
                Console.WriteLine("//////////////////////////\n" + response);
            }
            else
            {
                response = await _service.UpdateClienteAsync(cliente);
            }

            if (response)
            {
                return RedirectToAction("Index","Cliente");
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int idCliente)
        {
            var response = await _service.DeleteClienteAsync(idCliente);

            if (response)
            {
                return RedirectToAction("Index", "Cliente");
            }
            else
            {
                return NoContent();
            }
        }


    }
}
