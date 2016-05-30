using System.Collections.Generic;

using Escyug.Nosology.Presentation.Views;
using Escyug.Nosology.ViewModels;

namespace Escyug.Nosology.Web.App.Forms.pages
{
    public partial class documents : PageBase<IDocumentsView>, IDocumentsView
    {
        protected override IDocumentsView GetView() { return this; }

        public IEnumerable<DocumentViewModel> DocumentsList
        {
            set
            {
                documentsListView.DataSource = value;
                documentsListView.DataBind();
            }
        }
    }
}