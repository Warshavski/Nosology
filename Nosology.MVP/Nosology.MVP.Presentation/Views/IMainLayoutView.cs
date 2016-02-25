using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escyug.Nosology.MVP.Presentation.Views
{
    public interface IMainLayoutView
    {
        Escyug.Nosology.MVP.Engine.User AuthUser { get; }
    }
}
