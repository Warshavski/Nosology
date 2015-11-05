using System;
using System.Web.Security;
using WebNosology.Presentation.Presenters;
using WebNosology.Presentation.Views;

namespace WebNosology.UI.WebApp.pages.account
{
    public partial class login : System.Web.UI.Page, ILoginView
    {
        private LoginPresenter _presenter;

        public login()
        {
            _presenter = new LoginPresenter(this);
        }

        private void Invoke(Action action)
        {
            if (action != null)
                action.Invoke();
        }

        #region Члены ILoginView

        public event Action Login;

        public string MCOD
        {
            get { return this.loginField.Value.Trim(); }
        }

        public string Password
        {
            get { return this.pwdField.Value.Trim(); }
        }

        public string[] UserInfo
        {
            set
            {
                if (value[0] == "true")
                {
                    bool persist =
                        this.checkBoxPersist.Attributes["checked"] == null ? false : true;

                    FormsAuthentication.RedirectFromLoginPage(
                        string.Format("{0}#{1}", value[1], value[2]), persist);
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
            this.checkButton.ServerClick += (send, args) => Invoke(Login);
            //{ throw new NotImplementedException(); };
        }
    }
}
