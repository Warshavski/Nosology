using System;
using System.Web;

namespace Escyug.Nosology.Web.App.Forms.pages.access
{
    /// <summary>
    /// Downloads handler with simple authorization check
    /// </summary>
    public sealed class Downloads : IHttpHandler
    {
        /*
        private Dictionary<string, string> _contentType = new Dictionary<string, string>() 
        {
            { "pdf", "application/pdf"},
            {"doc", "application/msword"},
            {"exe", "application/x-msdownload"}
        };
        */

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                if ((System.Web.HttpContext.Current.User != null) &&
                    System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    string path = "~/App_Data";

                    System.Web.HttpRequest request = System.Web.HttpContext.Current.Request;
                    string fileType = request.QueryString["fileType"];
                    string fileName = request.QueryString["fileName"];
                    string extension = System.IO.Path.GetExtension(fileName);

                    System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                    response.ClearContent();
                    response.Clear();
                    response.ContentType = "application/" + extension;
                    response.AddHeader("Content-Disposition",
                                       "attachment; filename=" + fileName + ";");
                    response.TransmitFile(
                        HttpContext.Current.Server.MapPath(
                            string.Format("{0}/{1}/{2}", path, fileType, fileName)));
                    response.Flush();
                    response.End();
                }
                else
                {
                    context.Response.Redirect("../errors/unauthorized.aspx");
                }
            }
            catch (NullReferenceException)
            {
                context.Response.Redirect("../errors/unauthorized.aspx");
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                context.Response.Redirect("../errors/notfound.aspx");
            }
            catch (System.IO.FileNotFoundException)
            {
                context.Response.Redirect("../errors/notfound.aspx");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}

/** PARAMS : 
 *     - file name
 *     - file extension
 *     - path
 */
/*
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
 */