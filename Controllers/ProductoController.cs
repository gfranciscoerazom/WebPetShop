using WebPetShop.Models;
using WebPetShop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;

namespace WebPetShop.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IService_API _service;

        public ProductoController(IService_API service)
        {
            _service = service;
        }

        public async Task<ActionResult> Index()
        {
            var productos = await _service.GetProductosAsync();

            return View(productos);
        }

        public async Task<ActionResult> Producto(int idProducto)
        {
            var producto = new Producto();

            ViewBag.Action = "Add";

            if (idProducto != 0)
            {
                producto = await _service.GetProductoAsync(idProducto);
                ViewBag.Action = "Edit";
            }

            return View(producto);
        }

        [HttpPost]
        public async Task<ActionResult> Save(Producto producto)
        {
            bool response;

            if (producto.ProductoId == 0)
            {
                response = await _service.AddProductoAsync(producto);
            }
            else
            {
                response = await _service.UpdateProductoAsync(producto);
            }

            if (response)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int idProducto)
        {
            var response = await _service.DeleteProductoAsync(idProducto);

            if (response)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return NoContent();
            }
        }
    }
}
