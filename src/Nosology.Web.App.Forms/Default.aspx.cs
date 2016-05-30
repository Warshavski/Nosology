using System;
using System.Threading.Tasks;
using System.Web.Security;

using Escyug.Nosology.Presentation.Views;

namespace Escyug.Nosology.Web.App.Forms
{
    public partial class Default : PageBase<ILoginView>, ILoginView
    {
        protected override ILoginView GetView() { return this; }

        // old version (non async)
        public event Action LogOn;

        public event Func<Task> LogOnAsync;

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

        Models.User ILoginView.AuthUser
        {
            set
            {
                Session["User"] = value;
                FormsAuthentication.RedirectFromLoginPage(value.UserName, this.IsPersist);
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
           /** old version (non async)
            * HiddenPwd.ValueChanged += (send, args) => Invoker.Invoke(LogOn);
            */

            HiddenPwd.ValueChanged += async (send, args) => await Invoker.InvokeAsync(LogOnAsync);
        }

        // hmmm...
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