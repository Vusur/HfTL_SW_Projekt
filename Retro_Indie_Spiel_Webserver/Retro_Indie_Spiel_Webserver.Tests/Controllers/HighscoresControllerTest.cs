using Microsoft.VisualStudio.TestTools.UnitTesting;
using Retro_Indie_Spiel_Webserver.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Retro_Indie_Spiel_Webserver.Tests.Controllers
{
    /// <summary>
    /// Testet den Highscores Controller.
    /// </summary>
    [TestClass]
    public class HighscoresControllerTest
    {
        /// <summary>
        /// Testet ob die Register bzw. Login Methode vorhanden ist.
        /// </summary>
        [TestMethod]
        public void Index()
        {
            HighscoresController controller = new HighscoresController();
            ActionResult result = controller.Index(new Models.HighscoreViewModel()) as ActionResult;
            Assert.IsNotNull(result);
        }
    }
}
