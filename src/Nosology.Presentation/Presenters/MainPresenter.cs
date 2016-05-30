using System;
using System.Text;
using System.Threading.Tasks;

using Ninject;

using Escyug.Nosology.Models.Repositories;

using Escyug.Nosology.Presentation.Common;
using Escyug.Nosology.Presentation.Views;


namespace Escyug.Nosology.Presentation.Presenters
{
    public sealed class MainPresenter : IPresenter<IMainView>
    {
        private readonly IMainTextBlockRepository _mainTextRepository;
        private IMainView _view;

        [Ninject.Inject]
        public MainPresenter(IMainTextBlockRepository mainTextRepository)
        {
            _mainTextRepository = mainTextRepository;
        }

        public MainPresenter(IMainTextBlockRepository mainTextRepository, IMainView view)
            : this(mainTextRepository) 
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
            _view.PageLoadAsync += () => OnPageLoadAsync();
        }

        private void OnPageLoad()
        {
            //_view.TextBlock = _mainTextRepository.SelectAboutInfo();
        }

        private async Task OnPageLoadAsync()
        {
            _view.TextBlock = await _mainTextRepository.GetAboutInfoAsync();
        }
    }
}
