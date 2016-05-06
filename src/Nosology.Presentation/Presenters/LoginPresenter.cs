using System;

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

        private void OnLogon()
        {
            var login = _view.Login.Trim();
            var password = _view.Password.Trim();

            try
            {
                var user = _loginService.Login(login, password);
                var userVM = new ViewModels.User(user.Name, user.Level, string.Empty);

                _view.AuthUser = userVM;
            }
            catch (TimeoutException)
            {
                _view.ErrorText = "Error! Server timeout";
            }
            catch (NullReferenceException)
            {
                _view.ErrorText = "Error! Check login or(and) password";
            }
            catch (ArgumentException)
            {
                _view.ErrorText = "Error! Account time expired";
            }
        }
    }
}
