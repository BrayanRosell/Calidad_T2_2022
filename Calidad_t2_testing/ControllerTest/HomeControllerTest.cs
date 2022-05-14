using CalidadT2.Controllers;
using CalidadT2.Models;
using CalidadT2.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calidad_t2_testing.ControllerTest
{
    [TestFixture]
    class HomeControllerTest
    {
        [Test]
        public void CasoIndex()
        {
            var repository = new Mock<IBookRepository>();
            repository.Setup(o => o.ObtenerLibrosConAutores()).Returns(new List<Libro>());
            var controller = new HomeController(repository.Object);
            var view = controller.Index() as ViewResult;

            Assert.AreEqual("Index", view.ViewName);
        }
    }
}
