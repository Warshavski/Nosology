using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;

using Escyug.Nosology.Data.Exceptions;
using Escyug.Nosology.Models.Services;

namespace Escyug.Nosology.Web.App.Controllers
{
    [AllowAnonymous]
    public sealed class AuthenticationController : Controller
    {
        private readonly ILoginService _loginService;

        public AuthenticationController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        // GET: Authentication
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Authenticate(string login, string password, bool isPersist)
        {
            try
            {
                var user = await _loginService.LoginAsync(login, password);
                FormsAuthentication.SetAuthCookie(user.Name, isPersist);

                var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index", "Home");
                return Json(new { Url = redirectUrl });
            }
            catch (RootObjectNotFoundException)
            {
                return new HttpStatusCodeResult(404, "User not found. Check login or(and) password");
            }
            catch (ArgumentException)
            {
                return new HttpStatusCodeResult(423, "Error. Expired date");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }

}