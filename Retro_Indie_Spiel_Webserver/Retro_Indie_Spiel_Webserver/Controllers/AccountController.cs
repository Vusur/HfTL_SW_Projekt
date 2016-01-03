using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Retro_Indie_Spiel_Webserver.Models;
using System.Text;
using System.Collections.Generic;

namespace Retro_Indie_Spiel_Webserver.Controllers
{
    /// <summary>
    /// Controller für die Verwaltung der Accounts.
    /// </summary>
    public class AccountController : Controller
    {

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        /// <summary>
        /// Leerer Konstruktor.
        /// </summary>
        public AccountController()
        {
        }

        /// <summary>
        /// Konstruktor mit userManager und signInManager.
        /// </summary>
        /// <param name="userManager">ApplicationUserManager</param>
        /// <param name="signInManager">ApplicationSignInManager</param>
        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        /// <summary>
        /// Wenn SignInManager bei get leer ist liefert es einen aus dem Context zurück.
        /// </summary>
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        /// <summary>
        /// Wenn UserManager bei get leer ist liefert es einen aus dem Context zurück.
        /// </summary>
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        /// <summary>
        /// Get: /Account
        /// Einloggen und Registrieren eines Users.
        /// </summary>
        /// <param name="model">AccountIndexViewModel bestehend aus Email, Name, Password, confirmPassword und md5Hash.</param>
        /// <returns>Ob der Benutzer registriert oder eingeloggt wurde und mögliche Fehler.</returns>
        public async Task<ActionResult> Index(AccountIndexViewModel model)
        {
            // Überprüfen ob das übergebende Model den Anforderungen entspricht die im 
            // AccountIndexViewModel in den Annotations und in den IdentityConfig.cs definiert wurden.
            if (ModelState.IsValid)
            {

                // md5Hash überprüfen.
                string source = model.Email + model.Name + model.Password + ApplicationDbContext.md5HashKey;
                string hash = ApplicationDbContext.GetMd5Hash(MD5.Create(), source);
                if (hash != model.md5Hash)
                {
                    return Content("401 Wrong Hash");
                }

                // Überprüfen ob der Name oder die Email schon vorhanden sind.
                var users = UserManager.Users.Where(u => u.Email == model.Email && u.UserName == model.Name);
                ApplicationUser user;
                if (users.Count() == 0)
                {
                    // Wenn der User noch nicht vorhanden ist einen neuen User registrieren.
                    user = new ApplicationUser { UserName = model.Name, Email = model.Email };
                    var result = await UserManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        
                        return Content("ok Register");
                    }
                    // Wenn Fehler aufgetreten sind diese dem Model hinzufügen.
                    AddErrors(result);
                }
                else
                {
                    // Wenn der User vorhanden ist, versuchen diesen einzuloggen.
                    user = users.First();
                    var result = await SignInManager.PasswordSignInAsync(model.Name, model.Password, false, shouldLockout: false);
                    switch (result)
                    {
                        case SignInStatus.Success:
                            return Content("ok Login");
                        case SignInStatus.Failure:
                        default:
                            ModelState.AddModelError("", "Ungültiger Anmeldeversuch.");
                            break;
                    }
                }
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
        /// <param name="disposing">Boolean ob der UserManager und SignInManager gelöscht werden soll.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }
            
        /// <summary>
        /// Aus dem Result die Error dem Model hinzufügen.
        /// </summary>
        /// <param name="result">Ergebnis eines Register versuches.</param>
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}