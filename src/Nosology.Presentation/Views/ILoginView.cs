using System;
using System.Threading.Tasks;

using Escyug.Nosology.Presentation.Common;

namespace Escyug.Nosology.Presentation.Views
{
    public interface ILoginView : IView
    {
        event Action LogOn;
        event Func<Task> LogOnAsync;

        string Login { get; }
        string Password { get; }

        string ErrorText { set; }

        bool IsPersist { get; }

        Models.User AuthUser { set; }
    }
}
