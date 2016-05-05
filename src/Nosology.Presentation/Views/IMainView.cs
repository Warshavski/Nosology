using System;

using Escyug.Nosology.Presentation.Common;

namespace Escyug.Nosology.Presentation.Views
{
    public interface IMainView : IView
    {
        string TextBlock { set; }
    }
}
