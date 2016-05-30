using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;

using Microsoft.AspNet.FriendlyUrls;

namespace Escyug.Nosology.Web.App.Forms
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
           /** TODO : 
            *    1.Try to configure routes
            */
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);
        }
    }
}
