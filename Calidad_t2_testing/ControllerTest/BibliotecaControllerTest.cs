using CalidadT2.Controllers;
using CalidadT2.Models;
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
    class BibliotecaControllerTest
    {
        [Test]
        public void CasoBiblioteca()
        {
            var claim = new Mock<IClaimService>();
            claim.Setup(o => o.ObtenerDatosBiblioteca()).Returns(new List<Biblioteca>());
            var controller = new BibliotecaController(claim.Object);
            var view = controller.Index() as ViewResult;

            Assert.AreEqual("Index", view.ViewName);
        }
        [Test]
        public void AddGet()
        {
            var claim = new Mock<IClaimService>();
            claim.Setup(o => o.ObtenerDatosBiblioteca()).Returns(new List<Biblioteca>());
            claim.Setup(s => s.GetLoggedUsername()).Returns(new Usuario());
            var controller = new BibliotecaController(claim.Object);
            var view = controller.Add(1) as RedirectToActionResult;

            Assert.AreEqual("Index", view.ActionName);
        }
        [Test]
        public void MarcarComoLeyendo()
        {
           

            var claim = new Mock<IClaimService>();
            claim.Setup(o => o.marcarComoLeyendo(1,new Usuario() { Id = 2})).Returns(new Biblioteca());
            claim.Setup(s => s.GetLoggedUsername()).Returns(new Usuario());
            var controller = new BibliotecaController(claim.Object);
            var view = controller.MarcarComoLeyendo(2) as RedirectToActionResult;

            Assert.AreEqual("Index", view.ActionName);
        }
        [Test]
        public void MarcarComoTerminado()
        {


            var claim = new Mock<IClaimService>();
            claim.Setup(o => o.marcarComoLeyendo(1, new Usuario() { Id = 3 })).Returns(new Biblioteca());
            claim.Setup(s => s.GetLoggedUsername()).Returns(new Usuario());
            var controller = new BibliotecaController(claim.Object);
            var view = controller.MarcarComoTerminado(2) as RedirectToActionResult;

            Assert.AreEqual("Index", view.ActionName);
        }

    }
}
