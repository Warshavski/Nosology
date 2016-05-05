using System;
using System.IO;

namespace Escyug.Nosology.Web.App.pages.access
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