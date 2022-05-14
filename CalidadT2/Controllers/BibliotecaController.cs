using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalidadT2.Constantes;
using CalidadT2.Models;
using CalidadT2.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalidadT2.Controllers
{
    [Authorize]
    public class BibliotecaController : Controller
    {
        private IClaimService claimService;

        public BibliotecaController(IClaimService claimService)
        { 
            this.claimService = claimService;
            claimService.setHttpContext(HttpContext);
        }

        [HttpGet]
        public IActionResult Index()
        {
            claimService.setHttpContext(HttpContext);
            Usuario user = claimService.GetLoggedUsername();

            var model = claimService.ObtenerDatosBiblioteca();

            return View("Index", model);
        }

        [HttpGet]
        public ActionResult Add(int libro)
        {
            claimService.setHttpContext(HttpContext);
            Usuario user = claimService.GetLoggedUsername();

            var biblioteca = new Biblioteca
            {
                LibroId = libro,
                UsuarioId = user.Id,
                Estado = ESTADO.POR_LEER
            };

            claimService.AddLibro(biblioteca);

             //TempData["SuccessMessage"] = "Se añádio el libro a su biblioteca";

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult MarcarComoLeyendo(int libroId)
        {
            claimService.setHttpContext(HttpContext);
            Usuario user = claimService.GetLoggedUsername();

            var libro = claimService.marcarComoLeyendo(libroId, user);
            claimService.GuardarEnDB();

            //TempData["SuccessMessage"] = "Se marco como leyendo el libro";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult MarcarComoTerminado(int libroId)
        {
            claimService.setHttpContext(HttpContext);
            Usuario user = claimService.GetLoggedUsername();

            var libro = claimService.marcarComoLeyendo(libroId, user);
            claimService.GuardarEnDB();

            //TempData["SuccessMessage"] = "Se marco como leyendo el libro";

            return RedirectToAction("Index");
        }

       
    }
}
