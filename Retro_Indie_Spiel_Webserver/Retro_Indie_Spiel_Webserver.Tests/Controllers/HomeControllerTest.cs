using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Retro_Indie_Spiel_Webserver;
using Retro_Indie_Spiel_Webserver.Controllers;

namespace Retro_Indie_Spiel_Webserver.Tests.Controllers
{
    /// <summary>
    /// Testet ob der Homecontroller Views zurückliefert.
    /// </summary>
    [TestClass]
    public class HomeControllerTest
    {
        /// <summary>
        /// Testet die Index Methode.
        /// </summary>
        [TestMethod]
        public void Index()
        {
            HomeController controller = new HomeController();            
            ViewResult result = controller.Index() as ViewResult;            
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Testet die Impressum Methode.
        /// </summary>
        [TestMethod]
        public void Impressum()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Impressum() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}
