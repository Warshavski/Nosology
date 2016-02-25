using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Escyug.Nosology.MVP.UI.WebApp.pages.shared
{
    public partial class _Main : System.Web.UI.MasterPage
    {
        public _Main()
        {
            
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            var usr = Session["User"] as Escyug.Nosology.MVP.Engine.User;

            if (usr != null)
            {
                this.userName.Text = (Session["User"] as Escyug.Nosology.MVP.Engine.User).Name;
                this.userLevel.Text = (Session["User"] as Escyug.Nosology.MVP.Engine.User).Level;
                this.signOutLink.ServerClick += (send, args) =>
                {
                    FormsAuthentication.SignOut();
                    FormsAuthentication.RedirectToLoginPage();
                };
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // ajax call test method
        //[System.Web.Services.WebMethod]
        //public static string GetCurrentTime()
        //{
        //    return "Hello " + "wat" + Environment.NewLine + "The Current Time is: "
        //        + DateTime.Now.ToString();
        //}
    }
}