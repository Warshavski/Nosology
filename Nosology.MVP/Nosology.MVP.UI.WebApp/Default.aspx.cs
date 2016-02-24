using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Escyug.Nosology.MVP.Presentation.Presenters;
using Escyug.Nosology.MVP.Presentation.Views;
using System.Web.Security;

namespace Escyug.Nosology.MVP.UI.WebApp
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
            get { return loginInput.Value.Trim(); }
        }

        public string Password
        {
            get { return pwdInput.Value.Trim(); }
        }

        public Escyug.Nosology.MVP.Engine.User AuthUser
        {
            set 
            {
                if (value != null)
                { 
                    Session["User"] = value;
                    bool persist = bool.Parse(this.HiddenChecked.Value);
                    FormsAuthentication.RedirectFromLoginPage(value.Name, persist);
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
            if (!Page.IsPostBack) 
            { 
                this.Session.Clear();
                //this.checkButton.ServerClick += (send, args) => Invoke(Login);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void checkButton_ServerClick(object sender, EventArgs e)
        {
            Invoke(Login);
        }
    }
}