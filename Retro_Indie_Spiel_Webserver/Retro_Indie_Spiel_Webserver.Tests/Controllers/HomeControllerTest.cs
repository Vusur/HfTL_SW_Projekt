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
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            HomeController controller = new HomeController();            
            ViewResult result = controller.Index() as ViewResult;            
            Assert.IsNotNull(result);
        }                
    }
}
