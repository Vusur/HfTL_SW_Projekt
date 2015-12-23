using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Retro_Indie_Spiel_Webserver.Controllers;
namespace Retro_Indie_Spiel_Webserver.Tests.Controllers
{
    [TestClass]
    public class AcccountControllerTest
    {
        [TestMethod]
        public void RegisterLogin()
        {
            AccountController account = new AccountController();

            account.Index();

        }
    }
}
