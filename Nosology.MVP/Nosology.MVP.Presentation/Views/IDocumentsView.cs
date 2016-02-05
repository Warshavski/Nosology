using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escyug.Nosology.MVP.Presentation.ModelView;

namespace Escyug.Nosology.MVP.Presentation.Views
{
    public interface IDocumentsView
    {
        event Action Load;

        List<TemplateFileMV> DocumentsList { set; }
    }
}
