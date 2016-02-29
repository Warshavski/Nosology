using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Escyug.Nosology.MVP.Presentation.Views;
using Escyug.Nosology.MVP.Presentation.Presenters;
using System.Web.UI.HtmlControls;

namespace Escyug.Nosology.MVP.UI.WebApp.Degrade.pages
{
    public partial class downloads : System.Web.UI.Page, IDownloadsView
    {
        private readonly DownloadsPresenter _presenter;

        public downloads()
        {
            _presenter = new DownloadsPresenter(this);
        }

        private void Invoke(Action action)
        {
            if (action != null)
                action.Invoke();
        }

        #region IDownloadsView members

        public event Action PageLoad;

        public List<Presentation.ModelView.TemplateFileMV> FilesList
        {
            set 
            { 
                filesList.DataSource = value;
                filesList.DataBind();
            }
        }

        #endregion

        protected void Page_Init(object sender, EventArgs e)
        {
            this.Load += (send, args) => Invoke(PageLoad);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}


/* Test version
 *  // test class
 *  internal sealed class DocumentTemplate
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Icon { get; set; }

        public DocumentTemplate(int id, string title, string link, string icon)
        {
            Id = id;
            Title = title;
            Link = link;
            Icon = icon;
        }
    }
 * 
 *  protected void Page_Load(object sender, EventArgs e)
    {
            test version (used test class DocumentTemplate)
        this.AsyncMode = true;
        string path = string.Format("{0}\\{1}", HttpRuntime.AppDomainAppPath, "App_Data\\files");
        var icon = "insert_drive_file"; //"fa fa-file-text-o";

        DirectoryInfo dirInfo = new DirectoryInfo(path);

        List<DocumentTemplate> docs = new List<DocumentTemplate>();
        int id = 0;
        foreach (var element in dirInfo.GetFiles())
            docs.Add(new DocumentTemplate(++id, element.Name, element.FullName, icon));

        docsList.DataSource = docs;
        docsList.DataBind();
            
    }
 * 
 *  protected void FileLink_ServerClick(object sender, EventArgs e)
    {
        var value = (sender as HtmlControl).Attributes["datalink"];
        Response.Redirect("../handlers/FileDownload.ashx?fileName=" + value);  
    }
 */