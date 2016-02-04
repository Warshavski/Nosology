using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escyug.Nosology.MVP.Engine;
using Escyug.Nosology.MVP.Presentation.Views;

namespace Escyug.Nosology.MVP.Presentation.Presenters
{
    public sealed class DocumentsPresenter
    {
        private readonly IDocumentsView _view;

        public DocumentsPresenter(IDocumentsView view)
        {
            _view = view;
            _view.Load += () => OnLoad();
        }

        private void OnLoad()
        {
            _view.DocumentsList = TemplateFile.LoadDocuments();
        }
    }
}
