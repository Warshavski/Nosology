using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Escyug.Nosology.MVP.UI.WebApp.Degrade.pages.shared
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
                this.userName.Text = usr.Name;
                this.userLevel.Text = usr.Level;

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
    }
}