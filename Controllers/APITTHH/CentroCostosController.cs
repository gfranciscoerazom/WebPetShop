
using Microsoft.AspNetCore.Mvc;
using WebPetShop.Models;
using WebPetShop.Models.APITTHH;
//using WebPetShop.Models.APITTHH;
using WebPetShop.Services;

namespace WebPetShop.Controllers.APITTHH
{
	public class CentroCostosController : Controller
	{
		private readonly IService_API _service;

		public CentroCostosController(IService_API service)
		{
			_service = service;
		}

		public async Task<ActionResult> Index()
		{
			var costos = await _service.CostosSelectAsync();

            return View(costos);
		}


		public async Task<ActionResult> CostosInsertAsync(Costos costos)
		{
            var costo = new Costos();

            ViewBag.Action = "Add";

            if (costos.Codigo != 0)
            {
                costos = await _service.CostosInsertAsync(costos);

                ViewBag.Action = "Edit";
            }

            return View(costo);
        }

		public async Task<ActionResult> CostosDeleteAsync(Costos costos)
		{
			var costo = new Costos();
			ViewBag.Action = "Delete";

			if (costos.Codigo != 0)
			{
				costos = await _service.CostosDeleteAsync(costos);
			}
			return View(costos);
        }

		public async Task<ActionResult> CostosUpdateAsync(Costos costos)
		{
			var costo = new Costos();
            ViewBag.Action = "Update";

            if (costos.Codigo != 0)
			{
                costos = await _service.CostosUpdateAsync(costos);
            }
            return View(costo);
		}
	}
}
