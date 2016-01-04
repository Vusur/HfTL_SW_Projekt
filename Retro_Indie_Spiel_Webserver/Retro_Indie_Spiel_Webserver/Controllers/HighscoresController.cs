using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Retro_Indie_Spiel_Webserver.Models;
using System.Security.Cryptography;

namespace Retro_Indie_Spiel_Webserver.Controllers
{
    /// <summary>
    /// Controller für die Highscore verwaltung.
    /// </summary>
    public class HighscoresController : Controller
    {
        /// <summary>
        /// Datenbankcontext bzw. Verbindung aus dem Entity Framework.
        /// </summary>
        private ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// GET: /Highscores/List
        /// </summary>
        /// <returns>Liefert die Json der gesamten Highscores.</returns>
        public ActionResult List()
        {
            var highscores = db.Highscores.Include(e => e.User).OrderByDescending(e => e.Score).ToList();
            List<HighscoreListViewModel> list = new List<HighscoreListViewModel>();
            int counter = 1;
            // Alle gefundenen Highscores in ein ListViewModel für die Anzeige reinschreiben.
            foreach (HighscoreModel high in highscores)
            {
                list.Add(HighscoreListViewModel.build(high, counter));
                counter++;
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// GET: /Highscores
        /// Wird Standardmäßig aufgerufen und schreibt einen Eintrag in die Highscoreliste
        /// </summary>
        /// <param name="highscoreViewModel">HighscoreViewModel bestehend aus Name, Score und md5Hash, andere Parmeter können nicht übergeben werden.</param>
        /// <returns>Ob der Highscore eingetragen wurde und mögliche Fehler.</returns>
        public ActionResult Index([Bind(Include = "Name,Score,md5Hash")] HighscoreViewModel highscoreViewModel)
        {
            if (ModelState.IsValid)
            {
                // md5Hash überprüfen
                string source = highscoreViewModel.Name + highscoreViewModel.Score + ApplicationDbContext.md5HashKey;
                string hash = ApplicationDbContext.GetMd5Hash(MD5.Create(), source);
                if (hash != highscoreViewModel.md5Hash)
                {
                    return Content("401 Wrong Hash");
                }

                // Überprüfung ob der User vorhanden ist
                ApplicationUser User = db.Users.Where(e => e.UserName == highscoreViewModel.Name).FirstOrDefault();
                if (User == null)
                {
                    return Content("404 Not Found");
                }

                // Überprüfen das es der erste Eintrag ist
                HighscoreModel highscoreModel = new HighscoreModel
                {
                    UserId = User.Id,
                    Score = highscoreViewModel.Score
                };
                if (db.Highscores.Where(e => e.Score == highscoreModel.Score && e.UserId == highscoreModel.UserId).Count() == 0)
                {
                    db.Highscores.Add(highscoreModel);
                    db.SaveChanges();
                    return Content("Ok First");
                }

                return Content("Ok Already");
            }

            // Fehler zurückgeben
            string errorList = "";
            foreach (ModelState modelState in ViewData.ModelState.Values)
            {
                foreach (ModelError error in modelState.Errors)
                {
                    errorList += " // " + error.ErrorMessage;
                }
            }
            return Content("Error: " + errorList);
        }

        /// <summary>
        /// Methode für das Löschen des Controllers.
        /// </summary>
        /// <param name="disposing">Boolean ob die db Verbindung gelöscht werden soll.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
