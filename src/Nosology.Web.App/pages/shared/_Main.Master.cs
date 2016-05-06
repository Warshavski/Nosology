using System;
using System.Web.Security;

using Escyug.Nosology.ViewModels;

namespace Escyug.Nosology.Web.App.pages.shared
{
    public partial class _Main : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            var usr = Session["User"] as ViewModels.User;

            if (usr != null)
            {
                this.userName.Text = (Session["User"] as ViewModels.User).Name;
                this.userLevel.Text = (Session["User"] as ViewModels.User).Level;
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