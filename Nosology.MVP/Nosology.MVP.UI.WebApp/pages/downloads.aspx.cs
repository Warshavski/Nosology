using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Escyug.Nosology.MVP.UI.WebApp.pages
{
    public partial class downloads : System.Web.UI.Page
    {
        internal sealed class DocumentTemplate
        {
            public string Title { get; set; }
            public string Link { get; set; }
            public string Icon { get; set; }

            public DocumentTemplate(string title, string link, string icon)
            {
                Title = title;
                Link = link;
                Icon = icon;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.AsyncMode = true;

            string path = string.Format("{0}\\{1}", HttpRuntime.AppDomainAppPath, "App_Data\\docs");
            var icon = "fa fa-file-text-o";

            DirectoryInfo dirInfo = new DirectoryInfo(path);

            List<DocumentTemplate> docs = new List<DocumentTemplate>();
            foreach (var element in dirInfo.GetFiles())
                docs.Add(new DocumentTemplate(element.Name, element.FullName, icon));

            docsList.DataSource = docs;
            docsList.DataBind();
        }
    }
}