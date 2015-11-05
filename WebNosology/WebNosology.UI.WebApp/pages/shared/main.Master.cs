using System;
using System.Web.Security;

namespace WebNosology.UI.WebApp.pages.shared
{
    public partial class main : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            this.signOutLink.ServerClick += (send, args) =>
            {
                FormsAuthentication.SignOut();
                Response.Redirect("~/pages/account/login.aspx");
            };
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string[] splitedString = Context.User.Identity.Name.Split('#');

            this.userName.Text = splitedString[0];
            this.userLevel.Text = string.Format("Уровень : {0}", splitedString[1]);
        }
    }
}
