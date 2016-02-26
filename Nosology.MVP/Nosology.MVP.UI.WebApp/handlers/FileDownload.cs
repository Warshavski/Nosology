using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;


namespace Escyug.Nosology.MVP.UI.WebApp
{
    internal sealed class FileDownload : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            System.Web.HttpRequest request = System.Web.HttpContext.Current.Request;
            string fileName = request.QueryString["fileName"];

            //System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            //response.ClearContent();
            //response.Clear();
            //response.ContentType = "text/plain";
            //response.AddHeader("Content-Disposition",
            //                   "attachment; filename=" + fileName + ";");
            //response.TransmitFile(System.Web.HttpContext.Current.Server.MapPath(fileName));
            //response.Flush();
            //response.End();

            // Get the physical Path of the file
            string filepath = string.Format("{0}\\App_Data\\files\\{1}",
                System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + fileName);

            // Create New instance of FileInfo class to get the properties of the file being downloaded
            FileInfo file = new FileInfo(filepath);

            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;

            // Checking if file exists
            if (file.Exists)
            {
                // Clear the content of the response
                response.ClearContent();

                // LINE1: Add the file name and attachment, which will force the open/cance/save dialog to show, to the header
                response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", file.Name));

                // Add the file size into the response header
                response.AddHeader("Content-Length", file.Length.ToString());

                // Set the ContentType
                response.ContentType = "text/plain";

                // Write the file into the response (TransmitFile is for ASP.NET 2.0. In ASP.NET 1.1 you have to use WriteFile instead)
                response.TransmitFile(file.FullName);

                // End the response
                response.Flush();
                response.End();
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