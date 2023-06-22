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
        return View();
    }

    public async Task<ActionResult> Login()
    {
        return View();
    }

    public async Task<ActionResult> LoginOnClick(Usuario usr)
    {
        var usuarioOutputArray = await _service.GetUsuarioOutputsAsync(new Usuario
        {
            usuario = usr.usuario,
            password = usr.password,
        });
        var usuarioOutput = usuarioOutputArray.FirstOrDefault();
        if (usuarioOutput.OBSERVACION.Equals("INGRESO EXITOSO"))
        {
            return RedirectToAction("Index");
        }

        return NoContent();
    }
}
