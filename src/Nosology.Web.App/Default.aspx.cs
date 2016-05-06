using System;
using System.Web.Security;

using Escyug.Nosology.Presentation.Views;

namespace Escyug.Nosology.Web.App
{
    public partial class Default : PageBase<ILoginView>, ILoginView
    {
        protected override ILoginView GetView() { return this; }

        public event Action Logon;

        public string Login
        {
            get { return HiddenLogin.Value; }
        }

        public string Password
        {
            get { return HiddenPwd.Value; }
        }

        public string ErrorText
        {
            set { this.errorLabel.Text = value; }
        }

        // ?? useless ??
        public bool IsPersist
        {
            get { return bool.Parse(this.HiddenChecked.Value); }
        }

        public ViewModels.User AuthUser
        {
            set
            {
                Session["User"] = value;
                FormsAuthentication.RedirectFromLoginPage(value.Name, this.IsPersist);
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            HiddenPwd.ValueChanged += (send, args) => Invoker.Invoke(Logon);
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