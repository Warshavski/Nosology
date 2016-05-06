using System.Collections.Generic;

using Escyug.Nosology.Presentation.Views;

namespace Escyug.Nosology.Web.App.pages
{
    public partial class downloads : PageBase<IDownloadsView>, IDownloadsView
    {
        protected override IDownloadsView GetView() { return this; }

        public IEnumerable<ViewModels.TemplateFile> DocumentsList
        {
            set
            {
                filesList.DataSource = value;
                filesList.DataBind();
            }
        }
    }
}