using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Escyug.Nosology.MVP.Engine;
using Escyug.Nosology.MVP.Presentation.Views;

namespace Escyug.Nosology.MVP.Presentation.Presenters
{
    public class MainPresenter
    {
        private readonly IMainView _view;

        public MainPresenter(IMainView view)
        {
            _view = view;
            _view.PageLoad += () => OnLoad();
        }

        private void OnLoad()
        {
            ContentService service = new ContentService();
            _view.TextBlock = service.LoadMainContent();
        }
    }
}
