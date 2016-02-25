using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escyug.Nosology.MVP.Presentation.Views;

namespace Escyug.Nosology.MVP.Presentation.Presenters
{
    public sealed class MainLayoutPresenter
    {
        private readonly IMainLayoutView _view;

        public MainLayoutPresenter(IMainLayoutView view)
        {
            _view = view;
        }
    }
}
