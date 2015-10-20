using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

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
