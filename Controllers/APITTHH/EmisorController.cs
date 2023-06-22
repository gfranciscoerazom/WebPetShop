using Microsoft.AspNetCore.Mvc;
using WebPetShop.Services;

namespace WebPetShop.Controllers.APITTHH;

public class EmisorController : Controller
{
    private readonly IService_API _service;

    public EmisorController(IService_API service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var emisores = await _service.GetEmisoresAsync();
        return View(emisores);
    }
}
