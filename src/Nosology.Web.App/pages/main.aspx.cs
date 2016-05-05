using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Escyug.Nosology.Presentation.Views;

namespace Escyug.Nosology.Web.App.pages
{
    public partial class main : PageBase<IMainView>, IMainView
    {
        protected override IMainView GetView() { return this; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string TextBlock
        {
            set { contentLiteral.Text = value; }
        }
    }
}