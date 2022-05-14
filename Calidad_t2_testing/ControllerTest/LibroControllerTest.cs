using CalidadT2.Controllers;
using CalidadT2.Models;
using CalidadT2.Repositorio;
using CalidadT2.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calidad_t2_testing.ControllerTest
{
    [TestFixture]
    class LibroControllerTest
    {
        [Test]
        public void CasoDetalle()
        {
            var claim = new Mock<IClaimService>();


            var repository = new Mock<IBookRepository>();
            repository.Setup(o => o.ObtenerFirst(1)).Returns(new Object());

            var controller = new LibroController(repository.Object, claim.Object);
            var view = controller.Details(1) as ViewResult;

            Assert.AreEqual("Details", view.ViewName);
        }
        [Test]
        public void CasoAddComentary()
        {
            var repository = new Mock<IBookRepository>();

            var claim = new Mock<IClaimService>();
            claim.Setup(o => o.AddComentario(new Comentario { Texto = "abc" })).Returns(new Comentario());
            var controller = new LibroController(repository.Object, claim.Object);
            var view = controller.AddComentario(new Comentario { Texto = "abc" }) as RedirectToActionResult;

            Assert.AreEqual("Details", view.ActionName);
        }
    }
}
