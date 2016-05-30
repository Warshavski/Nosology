using System.Collections.Generic;

using Escyug.Nosology.Presentation.Views;
using Escyug.Nosology.ViewModels;

namespace Escyug.Nosology.Web.App.Forms.pages
{
    public partial class downloads : PageBase<IDownloadsView>, IDownloadsView
    {
        protected override IDownloadsView GetView() { return this; }

        public IEnumerable<FileViewModel> FilesList
        {
            set
            {
                filesListView.DataSource = value;
                filesListView.DataBind();
            }
        }
    }
}