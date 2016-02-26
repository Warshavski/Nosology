using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Escyug.Nosology.MVP.Presentation.Views
{
    public interface IDownloadsView
    {
        event Action PageLoad;

        List<Escyug.Nosology.MVP.Presentation.ModelView.TemplateFileMV> FilesList { set; }
    }
}
