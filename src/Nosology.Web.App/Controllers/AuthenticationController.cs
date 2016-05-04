using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;

using Escyug.Nosology.Models.Services;


namespace Escyug.Nosology.Web.App.Controllers
{
    /*
     * TODO : 
     *  1. Implement async controller
     */

    [AllowAnonymous]
    public sealed class AuthenticationController : Controller
    {
        private readonly ILoginService _loginService;

        public AuthenticationController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        // GET: Authentication
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authenticate(string login, string password)
        {
            try
            {
                var user = _loginService.Login(login, password);

                FormsAuthentication.SetAuthCookie(user.Name, false);

                return RedirectToAction("Index", "Home");
            }
            catch (NullReferenceException)
            {
                return View("Login");
            }
            catch (TimeoutException)
            {
                return View("Login");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }

}