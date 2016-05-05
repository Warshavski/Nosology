using System;
using System.Text;
using System.IO;

using Ninject;

using Escyug.Nosology.Models.Repositories;

using Escyug.Nosology.Presentation.Common;
using Escyug.Nosology.Presentation.Views;

namespace Escyug.Nosology.Presentation.Presenters
{
    public sealed class MainPresenter : IPresenter<IMainView>
    {
        private readonly IAboutRepository _aboutRepository;
        private IMainView _view;

        [Ninject.Inject]
        public MainPresenter(IAboutRepository aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }

        public MainPresenter(IAboutRepository aboutRepository, IMainView view) 
            : this(aboutRepository) 
        {
            InjectView(view);
        }

        //public MainPresenter(IAboutRepository aboutRepository, IMainView view)
        //{
        //    _view = view;
        //   
        //    _view.PageLoad += () => OnPageLoad();
        //}

        public void InjectView(IMainView view)
        {
            _view = view;

            _view.PageLoad += () => OnPageLoad();
        }

        private void OnPageLoad()
        {
            _view.TextBlock = _aboutRepository.SelectAboutInfo();
        }

    }
}
