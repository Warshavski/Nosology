using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escyug.Nosology.MVP.Engine;
using Escyug.Nosology.MVP.Presentation.Views;

namespace Escyug.Nosology.MVP.Presentation.Presenters
{
    public sealed class DownloadsPresenter
    {
        private readonly IDownloadsView _view;

        public DownloadsPresenter(IDownloadsView view)
        {
            _view = view;
            _view.Load += () => OnLoad();
        }

        private void OnLoad()
        {
            _view.FilesList = TemplateFile.LoadFiles();
        }
    }
}
