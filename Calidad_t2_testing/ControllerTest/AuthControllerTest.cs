using CalidadT2.Controllers;
using CalidadT2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calidad_t2_testing.ControllerTest
{
    [TestFixture]
    class AuthControllerTest
    {
        [Test]
        public void CasoLoginGet()
        {

             
             var Authcontroller = new AuthController(null);
            var view = Authcontroller.Login() as ViewResult;
            Assert.AreEqual("Login", view.ViewName);
        }
        [Test]
        public void CasoLoginPost()
        {
            var Authcontroller = new AuthController(null);
            var view = Authcontroller.Login("prueba", "prueba") as ViewResult;
            Assert.AreEqual("Login", view.ViewName);
        }
        
    }
}
