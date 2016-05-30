using System.Collections.Generic;

using Escyug.Nosology.Presentation.Common;
using Escyug.Nosology.ViewModels;

namespace Escyug.Nosology.Presentation.Views
{
    public interface IDocumentsView : IView
    {
        IEnumerable<DocumentViewModel> DocumentsList { set; }
    }
}
