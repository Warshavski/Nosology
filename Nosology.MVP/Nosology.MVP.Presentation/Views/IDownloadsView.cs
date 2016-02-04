using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escyug.Nosology.MVP.Presentation.Views
{
    public interface IDownloadsView
    {
        event Action Load;

        List<Escyug.Nosology.MVP.Engine.TemplateFile> FilesList { set; }
    }
}
