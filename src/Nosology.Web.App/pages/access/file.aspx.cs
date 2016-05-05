using System;
using System.IO;

namespace Escyug.Nosology.Web.App.pages.access
{
    public partial class file : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /** PARAMS : 
            *     - file name
            *     - file extension
            *     - path
            */
            string path = "~/App_Data";

            System.Web.HttpRequest request = System.Web.HttpContext.Current.Request;
            string fileName = request.QueryString["fileName"];

            string extension = Path.GetExtension(fileName);

            Response.ContentType = string.Format("application/{0}", extension);

            // filename and format in which file gonna be save
            Response.AppendHeader("Content-Disposition", string.Format("attachment; filename={0}", fileName));

            // write the file to the Response
            const int bufferLength = 10000;
            byte[] buffer = new Byte[bufferLength];
            int length = 0;
            Stream downloadStream = null;

            try
            {
                downloadStream = new FileStream(
                    Server.MapPath(
                        string.Format("{0}/files/{1}", path, fileName)), FileMode.Open, FileAccess.Read);
                do
                {
                    if (Response.IsClientConnected)
                    {
                        length = downloadStream.Read(buffer, 0, bufferLength);
                        Response.OutputStream.Write(buffer, 0, length);
                        buffer = new Byte[bufferLength];
                    }
                    else
                    {
                        length = -1;
                    }
                }
                while (length > 0);

                Response.Flush();
                Response.End();
            }
            catch (FileNotFoundException)
            {
                Response.Redirect("error.aspx");
            }
            finally
            {
                if (downloadStream != null)
                    downloadStream.Close();
            }
        }
    }
}