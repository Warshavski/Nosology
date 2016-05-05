using System.Collections.Generic;

using Escyug.Nosology.Presentation.Common;

namespace Escyug.Nosology.Presentation.Views
{
    public interface IDownloadsView : IView
    {
        IEnumerable<ViewModels.TemplateFile> DocumentsList { set; }
    }
}
