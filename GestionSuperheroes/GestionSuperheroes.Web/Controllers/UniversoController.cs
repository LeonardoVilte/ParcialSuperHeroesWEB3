using GestionSuperheroes.Data.EF;
using GestionSuperheroes.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace GestionSuperheroes.Web.Controllers
{
	public class UniversoController : Controller
	{
		private readonly ILogica _logica;

		public UniversoController(ILogica logica)
		{
			_logica = logica;
		}

		public async Task<IActionResult> AgregarSuperheroe()
		{
			ViewBag.Universos = await _logica.ObtenerTodosLosUniversos();
			return View();
		}

        [HttpPost]
        public async Task<IActionResult> AgregarSuperheroe(Superheroe superheroe)
        {
            if (ModelState.IsValid && superheroe.IdUniverso > 0)
            {
                await _logica.AgregarSuperheroe(superheroe);
                return RedirectToAction("Listar");
            }

			ViewBag.Universos = await _logica.ObtenerTodosLosUniversos();
			return View(superheroe);
        }

        public async Task<IActionResult> Listar(int? idUniverso)
        {
            ViewBag.Universos = await _logica.ObtenerTodosLosUniversos();
            ViewBag.IdUniversoSeleccionado = idUniverso ?? 0;

            var superheroes = idUniverso.HasValue && idUniverso.Value != 0 ?
                await _logica.ListarSuperheroesPorUniverso(idUniverso.Value) :
                await _logica.ListarTodosLosSuperheroes();

            return View(superheroes);
        }
        public async Task<IActionResult> EliminarSuperheroe(int idSuperheroe, int? idUniverso)
        {
            await _logica.EliminarSuperheroe(idSuperheroe);
            return RedirectToAction("Listar", new {idUniverso = idUniverso});
        }
    }
}
