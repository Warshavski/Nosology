using System;

namespace WebNosology.UI.WebApp
{
    /* 
     *
     */
    public partial class _Index : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            Response.Redirect("~/pages/account/login.aspx");
        }
    }
}
