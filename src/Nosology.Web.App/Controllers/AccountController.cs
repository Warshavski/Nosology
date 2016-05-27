using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

using Escyug.Nosology.Models;
using Escyug.Nosology.Models.Services;
using Escyug.Nosology.Web.App.ViewModels;

using Escyug.Nosology.Web.Common.Security;

namespace Escyug.Nosology.Web.App.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userService;

        public AccountController(UserManager<User> userService)
        {
            _userService = userService;
        }

        //
        // GET: /Account
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        //
        // POST: /Account/LogIn
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LogIn(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userService.FindAsync(model.UserName, model.Password);

                    if (user != null)
                    {
                        await SignInAsync(user, model.RememberMe);

                        Session.Add("user", user);

                        return RedirectToAction("Index", "Home"); //RedirectToLocal(returnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid username or password.");
                    }
                }
                catch (ArgumentException)
                {
                    ModelState.AddModelError("", "User account is out of date.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View("Index", model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOut()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Account");
        }

        #region Helpers

        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private async Task SignInAsync(User user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await _userService.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

            /** Add more custom claims here if you want. Eg HomeTown can be a claim for the User
             *
             * var homeclaim = new Claim(ClaimTypes.Country, user.HomeTown);
             * identity.AddClaim(homeclaim);
             * 
             */

            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        /* other helper methods 
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private bool HasPassword()
        {
            var user = _userService.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            Error
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        private class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties() { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        */

        #endregion
    }
}




/* Old archive code 
private readonly ILoginService _loginService;

public UserManager<User> UserManager { get; private set; }

public AccountController(ILoginService loginService)
{
    _loginService = loginService;
}

// GET: Account
public ActionResult Index()
{
    return View();
}

[HttpPost]
[AllowAnonymous]
[ValidateAntiForgeryToken]
public async Task<ActionResult> LogIn(LoginViewModel model)
{
    if (ModelState.IsValid)
    {
        var user = await UserManager.FindAsync(model.UserName, model.Password);
        if (user != null)
        {
            await SignInAsync(user, model.RememberMe);
            return RedirectToLocal(returnUrl);
        }
        else
        {
            ModelState.AddModelError("", "Invalid username or password.");
        }
    }

    // If we got this far, something failed, redisplay form
    return View(model);
            
    / *
    var user = await _loginService.LoginAsync(login, password);
    FormsAuthentication.SetAuthCookie(user.Name, isPersist);

    Session.Add("user", user);
    var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index", "Home");
    return Json(new { Url = redirectUrl });
    * /
}

*/