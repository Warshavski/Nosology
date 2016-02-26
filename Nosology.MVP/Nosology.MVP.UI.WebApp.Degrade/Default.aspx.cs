using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Escyug.Nosology.MVP.Presentation.Presenters;
using Escyug.Nosology.MVP.Presentation.Views;
using System.Web.Security;

namespace Escyug.Nosology.MVP.UI.WebApp.Degrade
{
    public partial class Default : System.Web.UI.Page, ILoginView
    {
        private readonly LoginPresenter _presenter;

        public Default()
        {
            _presenter = new LoginPresenter(this);
        }

        private void Invoke(Action action)
        {
            if (action != null)
                action.Invoke();
        }

        #region ILoginView members

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
            get { return bool.Parse(this.HiddenChecked.Value); }
        }

        public Escyug.Nosology.MVP.Engine.User AuthUser
        {
            set 
            {
                if (value != null)
                { 
                    Session["User"] = value;
                    
                    FormsAuthentication.RedirectFromLoginPage(value.Name, this.IsPersist);
                }
                else
                {
                    this.errorLabel.Text = "Ошибка! Проверьте логин и(или) пароль";
                }
            }
        }

        #endregion

        protected void Page_Init(object sender, EventArgs e)
        {
            HiddenPwd.ValueChanged += (send, args) => Invoke(Login);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((System.Web.HttpContext.Current.User != null) && 
                System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                // use formsauth instead of simple redirect
                Response.Redirect("/pages/main.aspx");
            }
            else
            {
                Session.Clear();
            }
                
        }
    }
}