using System;

using Ninject;

using Escyug.Nosology.Presentation.Common;

namespace Escyug.Nosology.Web.App.Forms
{
    public abstract class PageBase<TView> : Ninject.Web.PageBase, IView 
        where TView : IView
    {

        private IPresenter<TView> _presenter;

        [Inject]
        public IPresenter<TView> Presenter
        {
            set
            {
                _presenter = value;

                var view = GetView();
                _presenter.InjectView(view);
            }
        }

        protected abstract TView GetView();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!Page.IsPostBack && PageLoad != null)
                PageLoad.Invoke();
        }

        public event Action PageLoad;
    }
}