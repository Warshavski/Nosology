using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using Escyug.Nosology.Presentation.Views;

namespace Escyug.Nosology.Web.App
{
    public partial class Default : PageBase<ILoginView>, ILoginView
    {
        protected override ILoginView GetView() { return this; }

        public event Action Logon;

        public string Login
        {
            get { return "дзкк"; }
        }

        public string Password
        {
            get { return "дзкк"; }
        }

        public bool IsPersist
        {
            get { return false; }
        }

        public ViewModels.User AuthUser
        {
            set { Session["User"] = value; }
        }
    }
}