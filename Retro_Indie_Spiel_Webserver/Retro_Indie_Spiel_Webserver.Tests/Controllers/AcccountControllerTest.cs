using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Retro_Indie_Spiel_Webserver.Controllers;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace Retro_Indie_Spiel_Webserver.Tests.Controllers
{
    /// <summary>
    /// Testet den Account Controller.
    /// </summary>
    [TestClass]
    public class AcccountControllerTest
    {
        /// <summary>
        /// Testet ob die Register bzw. Login Methode vorhanden ist.
        /// </summary>
        [TestMethod]
        public void Index()
        {
            AccountController controller = new AccountController();
            Task<ActionResult> result = controller.Index(new Models.AccountIndexViewModel()) as Task<ActionResult>;
            Assert.IsNotNull(result);

        }
    }
}
