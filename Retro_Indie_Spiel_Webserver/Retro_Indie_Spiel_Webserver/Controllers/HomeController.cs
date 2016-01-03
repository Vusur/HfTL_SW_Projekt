using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Retro_Indie_Spiel_Webserver.Controllers
{
    /// <summary>
    /// Controller der Standardmäßig aufgerufen wird und die Startseite und die Impressumseite zurückliefert.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Wird Standardmäßig aufgerufen und liefert die Startseite zurück.
        /// </summary>
        /// <returns>View der Startseite</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Impressum Seite wird zurückgeliefert.
        /// </summary>
        /// <returns>View des Impressums.</returns>
        public ActionResult Impressum()
        {
            return View();
        }
    }
}