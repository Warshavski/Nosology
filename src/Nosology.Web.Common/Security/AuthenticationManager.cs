using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace Escyug.Nosology.Web.Common.Security
{
    /// <summary>
    ///     Implements SignIn, SignOut and security claims
    /// </summary>
    
    /** TODO : 
     *   1. Implement SignIn and SignOut (replace from Account controller)
     */
    public sealed class AuthenticationManager
    {
        /*
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public void SignIn(ClaimsIdentity identity, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }
        */
    }
}
