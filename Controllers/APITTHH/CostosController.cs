using Microsoft.AspNetCore.Mvc;
using WebPetShop.Models.APITTHH;
using WebPetShop.Services;

namespace WebPetShop.Controllers.APITTHH;

public class CostosController : Controller
{
    private readonly IService_API _service;

    public CostosController(IService_API service)
    {
        _service = service;
    }

    public async Task<ActionResult> Index()
    {
        var costos = await _service.CostosSelectAsync();

        return View(costos);
    }

    public async Task<ActionResult> Delete(int costoId, string nombre)
    {
        var costo = new Costos()
        {
            Codigo = costoId,
            NombreCentroCostos = nombre
        };
        var delete = await _service.CostosDeleteAsync(costo);
        return RedirectToAction("Index");
    }

    public async Task<ActionResult> Insert()
    {
        return View();
    }

    public async Task<ActionResult> SaveInsert(Costos costo)
    { 
        var insert = await _service.CostosInsertAsync(costo);
        return RedirectToAction("Index");
    }

    public async Task<ActionResult> Update(int costoId, string nombre)
    {
        var costo = new Costos()
        {
            Codigo = costoId,
            NombreCentroCostos = nombre
        };
        return View(costo);
    }

    public async Task<ActionResult> SaveUpdate(Costos costo)
    {
        var update = await _service.CostosUpdateAsync(costo);
        return RedirectToAction("Index");
    }
}
