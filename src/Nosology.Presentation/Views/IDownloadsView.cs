using System.Collections.Generic;

using Escyug.Nosology.Presentation.Common;
using Escyug.Nosology.ViewModels;

namespace Escyug.Nosology.Presentation.Views
{
    public interface IDownloadsView : IView
    {
        IEnumerable<FileViewModel> FilesList { set; }
    }
}
