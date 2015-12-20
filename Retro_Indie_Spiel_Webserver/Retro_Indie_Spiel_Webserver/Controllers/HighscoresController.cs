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

        // GET: Highscores
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

        public ActionResult Index([Bind(Include = "Name,Score,md5Hash")] HighscoreViewModel highscoreViewModel)
        {
            if (ModelState.IsValid)
            {
                string source = highscoreViewModel.Name + highscoreViewModel.Score + ApplicationDbContext.md5HashKey;
                string hash = ApplicationDbContext.GetMd5Hash(MD5.Create(), source);
                if (hash != highscoreViewModel.md5Hash)
                {
                    return new HttpUnauthorizedResult();
                }
                ApplicationUser User = db.Users.Where(e => e.UserName == highscoreViewModel.Name).First();
                if( User == null)
                {
                    return HttpNotFound();
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

        // GET: Highscores/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HighscoreModel highscoreModel = db.Highscores.Find(id);
            if (highscoreModel == null)
            {
                return HttpNotFound();
            }
            return View(highscoreModel);
        }

        // POST: Highscores/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,Score")] HighscoreModel highscoreModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(highscoreModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(highscoreModel);
        }

        // GET: Highscores/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HighscoreModel highscoreModel = db.Highscores.Find(id);
            if (highscoreModel == null)
            {
                return HttpNotFound();
            }
            return View(highscoreModel);
        }

        // POST: Highscores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HighscoreModel highscoreModel = db.Highscores.Find(id);
            db.Highscores.Remove(highscoreModel);
            db.SaveChanges();
            return RedirectToAction("Index");
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
