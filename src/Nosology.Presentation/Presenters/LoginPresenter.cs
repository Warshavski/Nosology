using Ninject;

using Escyug.Nosology.Models.Services;

using Escyug.Nosology.Presentation.Common;
using Escyug.Nosology.Presentation.Views;

namespace Escyug.Nosology.Presentation.Presenters
{
    public sealed class LoginPresenter : IPresenter<ILoginView>
    {
        private ILoginView _view;
        private readonly ILoginService _loginService;

        [Ninject.Inject]
        public LoginPresenter(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public LoginPresenter(ILoginService loginService, ILoginView view)
            : this(loginService)
        {
            //yes this is not a great idea, this constructor is provided for Unit Testing...
            InjectView(view); 
        }

        public void InjectView(ILoginView view)
        {
            _view = view;
            _view.Logon += () => OnLogon();
        }

        //public LoginPresenter(ILoginView view, ILoginService loginService)
        //{
        //    _view = view;
        //    _loginService = loginService;

        //    _view.Logon += () => OnLogon();
        //}

        private void OnLogon()
        {
            var login = _view.Login;
            var password = _view.Password;

            var user = _loginService.Login(login, password);
            var userVM = new ViewModels.User(user.Name, user.Level, string.Empty);

            _view.AuthUser = userVM;
        }
    }
}
