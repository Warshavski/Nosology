using System;

namespace WebNosology.UI.WebApp.pages
{
    public partial class error : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            this.backButton.ServerClick += (send, args) =>
            {
                string prevPage = Request.QueryString["aspxerrorpath"];
                Response.Redirect(prevPage);
            };
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
