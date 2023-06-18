using Microsoft.AspNetCore.Mvc;
using WebPetShop.Models.APITTHH;
using WebPetShop.Services;

namespace WebPetShop.Controllers.APITTHH;

public class UsuarioController : Controller
{
    private readonly IService_API _service;

    public UsuarioController(IService_API service)
    {
        _service = service;
    }

    public async Task<ActionResult> Index()
    {
        var usuarioOutput = await _service.GetUsuarioOutputsAsync(new Usuario
        {
            usuario = "5005",
            password = "5005U"
        });

        return View();
    }
}
