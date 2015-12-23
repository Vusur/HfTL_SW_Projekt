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
    public class HighscoresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Highscores/List
        // Liefert die Json der gesamten Highscores
        public ActionResult List()
        {
            var highscores = db.Highscores.Include(e => e.User).OrderByDescending(e => e.Score).ToList();
            List<HighscoreListViewModel> list = new List<HighscoreListViewModel>();
            int counter = 1;
            foreach(HighscoreModel high in highscores)
            {
                list.Add(HighscoreListViewModel.build(high, counter));
                counter++;
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        // POST: /Highscores
        // Schreibt einen Eintrag in die Highscoreliste
        [HttpPost]
        public ActionResult Index([Bind(Include = "Name,Score,md5Hash")] HighscoreViewModel highscoreViewModel)
        {
            if (ModelState.IsValid)
            {
                string source = highscoreViewModel.Name + highscoreViewModel.Score + ApplicationDbContext.md5HashKey;
                string hash = ApplicationDbContext.GetMd5Hash(MD5.Create(), source);
                if (hash != highscoreViewModel.md5Hash)
                {
                    return Content("401 Wrong Hash");
                }
                ApplicationUser User = db.Users.Where(e => e.UserName == highscoreViewModel.Name).FirstOrDefault();
                if ( User == null)
                {
                    return Content("404 Not Found");
                }
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
