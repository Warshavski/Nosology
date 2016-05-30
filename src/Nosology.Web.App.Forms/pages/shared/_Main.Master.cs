using System;
using System.Web.Security;

namespace Escyug.Nosology.Web.App.Forms.pages.shared
{
    public partial class _Main : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            var usr = Session["User"] as Models.User;

            if (usr != null)
            {
                this.userName.Text = (Session["User"] as Models.User).UserName;
                this.userLevel.Text = (Session["User"] as Models.User).Level;
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