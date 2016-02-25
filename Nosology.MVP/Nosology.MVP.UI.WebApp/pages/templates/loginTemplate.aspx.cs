using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Escyug.Nosology.MVP.Presentation.Presenters;
using Escyug.Nosology.MVP.Presentation.Views;
using System.Web.Security;

namespace Escyug.Nosology.MVP.UI.WebApp.pages.templates
{
    public partial class loginTemplate : System.Web.UI.Page, ILoginView
    {
        private readonly LoginPresenter _presenter;

        public loginTemplate()
        {
            _presenter = new LoginPresenter(this);
        }


        private void Invoke(Action action)
        {
            if (action != null)
                action.Invoke();
        }

        public event Action Login;

        public string MCOD
        {
            get { return HiddenLogin.Value.Trim(); }
        }

        public string Password
        {
            get { return HiddenPwd.Value.Trim(); }
        }

        public bool IsPersist
        {
            get { return bool.Parse(HiddenChecked.Value); }
        }

        public Engine.User AuthUser
        {
            set
            {
                if (value != null)
                {
                    Session["User"] = value;
                    Response.Redirect("/pages/main.aspx");
                    //bool persist = bool.Parse(this.HiddenChecked.Value);
                    //FormsAuthentication.RedirectFromLoginPage(value.Name, persist);
                }
                else
                {
                    this.errorLabel.Text = "Ошибка! Проверьте логин и(или) пароль";
                }
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            HiddenPwd.ValueChanged += (send, args) => Invoke(Login);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}