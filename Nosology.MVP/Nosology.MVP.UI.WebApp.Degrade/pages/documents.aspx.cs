using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Escyug.Nosology.MVP.Presentation.Views;
using Escyug.Nosology.MVP.Presentation.Presenters;
using Escyug.Nosology.MVP.Presentation.ModelView;
using System.Web.UI.HtmlControls;

namespace Escyug.Nosology.MVP.UI.WebApp.Degrade.pages
{
    public partial class documents : System.Web.UI.Page, IDocumentsView
    {
        private readonly DocumentsPresenter _presenter;

        public documents()
        {
            _presenter = new DocumentsPresenter(this);
        }

        private void Invoke(Action action)
        {
            if (action != null)
                action.Invoke();
        }

        public event Action PageLoad;

        public List<TemplateFileMV> DocumentsList
        {
            set
            {
                docsList.DataSource = value;
                docsList.DataBind();
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            this.AsyncMode = true;

            if (!Page.IsPostBack)
                Invoke(PageLoad);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Redirect("handlers/FileDownload.ashx?fileName=" + val);
        }
    }
}



/* test version
 * 
 * internal sealed class DocumentTemplate
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
 * 
 * 
 * string path = string.Format("{0}\\{1}", HttpRuntime.AppDomainAppPath, "App_Data\\docs");
    var icon = "fa fa-file-text-o";

    DirectoryInfo dirInfo = new DirectoryInfo(path);

    List<DocumentTemplate> docs = new List<DocumentTemplate>();
    foreach (var element in dirInfo.GetFiles())
        docs.Add(new DocumentTemplate(element.Name, element.FullName, icon));

    docsList.DataSource = docs;
    docsList.DataBind();
*/