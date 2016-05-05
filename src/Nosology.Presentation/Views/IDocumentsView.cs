using System.Collections.Generic;

using Escyug.Nosology.Presentation.Common;

namespace Escyug.Nosology.Presentation.Views
{
    public interface IDocumentsView : IView
    {
        IEnumerable<ViewModels.TemplateFile> FilesList { set; }
    }
}
