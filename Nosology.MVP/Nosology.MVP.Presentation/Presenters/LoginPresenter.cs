using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Escyug.Nosology.MVP.Engine;
using Escyug.Nosology.MVP.Presentation.Views;

namespace Escyug.Nosology.MVP.Presentation.Presenters
{
    public class LoginPresenter
    {
        private readonly ILoginView _view;

        public LoginPresenter(ILoginView view)
        {
            _view = view;
            _view.Login += () => OnLogin();
        }

        private void OnLogin()
        {
            StupidLogger logger = new StupidLogger();
            User usr = logger.Logon(_view.MCOD, _view.Password);

            _view.AuthUser = usr;
            //_view.IsAllow = false;
            
            //if (usr != null)
            //{
            //    _view.IsAllow = true;
                
            //}
        }
    }
}
