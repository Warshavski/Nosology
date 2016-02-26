using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Escyug.Nosology.MVP.UI.WebApp.Degrade.pages
{
    public partial class doc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string path = "~/App_Data";

            System.Web.HttpRequest request = System.Web.HttpContext.Current.Request;
            string fileName = request.QueryString["fileName"];

            string extension = Path.GetExtension(fileName);

            Response.ContentType = string.Format("application/{0}", extension);

            Response.TransmitFile(path);
        }
    }
}