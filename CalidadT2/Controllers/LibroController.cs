using System;
using System.Linq;
using CalidadT2.Models;
using CalidadT2.Repositorio;
using CalidadT2.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalidadT2.Controllers
{
    public class LibroController : Controller
    {
        private IBookRepository repository;
        private IClaimService claimService;
        public LibroController(IBookRepository repository, IClaimService claimService)
        {
            this.repository = repository;
            this.claimService = claimService;
            claimService.setHttpContext(HttpContext);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = repository.ObtenerFirst(id);
            return View("Details", model);
        }

        [HttpPost]
        public IActionResult AddComentario(Comentario comentario)
        {
            claimService.setHttpContext(HttpContext);
            Usuario user = claimService.GetLoggedUsername();

            comentario.UsuarioId = 1;
            comentario.Fecha = DateTime.Now;


            claimService.AddComentario(comentario);

            return RedirectToAction("Details", new { id = comentario.LibroId });
        }

       
    }
}
