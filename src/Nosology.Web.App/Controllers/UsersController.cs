using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Escyug.Nosology.Models.Services;

namespace Escyug.Nosology.Web.App.Controllers
{
    public class UsersController : Controller
    {
        private readonly ILoginService _loginService;

        public UsersController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public string GetUser()
        {
            var login = "дзкк";
            var password = "дзкк";

            try
            {
                var user = _loginService.Login(login, password);
                return user.Name + Environment.NewLine + user.Level;
            }
            catch (TimeoutException)
            {
                return "Timeout expired";
            }
            catch (NullReferenceException)
            {
                return "wow such error, so null exception";
            }
        }

        // GET: Users
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}