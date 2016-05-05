using System;

using Escyug.Nosology.Presentation.Common;

namespace Escyug.Nosology.Presentation.Views
{
    public interface ILoginView : IView
    {
        event Action Logon;

        string Login { get; }
        string Password { get; }

        bool IsPersist { get; }

        ViewModels.User AuthUser { set; }
    }
}
