using System;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;

using Ninject;

using Escyug.Nosology.Models;
using Escyug.Nosology.Models.Services;

using Escyug.Nosology.Presentation.Common;
using Escyug.Nosology.Presentation.Views;

namespace Escyug.Nosology.Presentation.Presenters
{
    public sealed class LoginPresenter : IPresenter<ILoginView>
    {
        private ILoginView _view;
        private readonly UserManager<User> _userService;

        [Ninject.Inject]
        public LoginPresenter(UserManager<User> userService)
        {
            _userService = userService;
        }

        public LoginPresenter(UserManager<User> userService, ILoginView view)
            : this(userService)
        {
            //yes this is not a great idea, this constructor is provided for Unit Testing...
            InjectView(view); 
        }

        public void InjectView(ILoginView view)
        {
            _view = view;

            _view.LogOn += () => OnLogOn();
            _view.LogOnAsync += () => OnLogOnAsync();
        }

        private void OnLogOn()
        {
            //var login = _view.Login.Trim();
            //var password = _view.Password.Trim();

            //try
            //{
            //    var user = _loginService.Login(login, password);
            //    var userVM = new ViewModels.User(user.Name, user.Level, string.Empty);

            //    _view.AuthUser = userVM;
            //}
            //catch (TimeoutException)
            //{
            //    _view.ErrorText = "Error! Server timeout";
            //}
            //catch (NullReferenceException)
            //{
            //    _view.ErrorText = "Error! Check login or(and) password";
            //}
            //catch (ArgumentException)
            //{
            //    _view.ErrorText = "Error! Account time expired";
            //}
        }

        private async Task OnLogOnAsync()
        {
            var userLogin = _view.Login.Trim();
            var userPassword = _view.Password.Trim();

            var user = await _userService.FindAsync(userLogin, userPassword);
            if (user != null)
            {
                _view.AuthUser = user;
            }
            else
            {
                _view.ErrorText = "Error. Check login or(and) password";
            }
        }
    }
}
