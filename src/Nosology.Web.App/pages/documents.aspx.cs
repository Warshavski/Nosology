using System.Collections.Generic;

using Escyug.Nosology.Presentation.Views;

namespace Escyug.Nosology.Web.App.pages
{
    public partial class documents : PageBase<IDocumentsView>, IDocumentsView
    {
        protected override IDocumentsView GetView() { return this; }

        public IEnumerable<ViewModels.TemplateFile> FilesList
        {
            set
            {
                docsList.DataSource = value;
                docsList.DataBind();
            }
        }
    }
}