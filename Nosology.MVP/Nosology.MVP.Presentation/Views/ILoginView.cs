using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Escyug.Nosology.MVP.Presentation.Views
{
    public interface ILoginView
    {
        event Action Login;

        string MCOD { get; }
        string Password { get; }

        bool IsPersist { get; }

        Escyug.Nosology.MVP.Engine.User AuthUser { set; }

        //bool IsAllow { set; }
    }
}
