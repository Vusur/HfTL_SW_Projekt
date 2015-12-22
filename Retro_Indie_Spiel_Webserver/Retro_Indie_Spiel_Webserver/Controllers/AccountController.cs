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
    [Authorize]
    public class AccountController : Controller
    {

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

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

        // Get /Account
        // Einloggen und Registrieren eines Users
        [AllowAnonymous]
        public async Task<ActionResult> Index(AccountIndexViewModel model)
        {

            if (ModelState.IsValid)
            {
                string source = model.Email + model.Name + model.Password + ApplicationDbContext.md5HashKey;
                string hash = ApplicationDbContext.GetMd5Hash(MD5.Create(), source);
                if (hash != model.md5Hash)
                {
                    return Content("401 Wrong Hash");
                }
                var users = UserManager.Users.Where(u => u.Email == model.Email && u.UserName == model.Name);
                ApplicationUser user;
                if (users.Count() == 0)
                {
                    user = new ApplicationUser { UserName = model.Name, Email = model.Email };
                    var result = await UserManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        
                        return Content("ok Register");
                    }
                    AddErrors(result);
                }
                else
                {
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
            

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}