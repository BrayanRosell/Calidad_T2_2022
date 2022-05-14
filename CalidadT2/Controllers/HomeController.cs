using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;
using CalidadT2.Repositorio;

namespace CalidadT2.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository repository;
        public HomeController(IBookRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = repository.ObtenerLibrosConAutores();
            return View("Index", model);
        }
    }
}
