using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Escyug.Nosology.MVP.Presentation.Views;
using Escyug.Nosology.MVP.Presentation.Presenters;

namespace Escyug.Nosology.MVP.UI.WebApp.Degrade.pages
{
	public partial class main : System.Web.UI.Page, IMainView
	{
        private readonly MainPresenter _presenter;

        public main()
        {
            _presenter = new MainPresenter(this);
        }

        private void Invoke(Action action)
        {
            if (action != null)
                action.Invoke();
        }

        #region IMainView members

        public event Action PageLoad;

        public string TextBlock
        {
            set { contentLiteral.Text = value; }
        }

        #endregion

        protected void Page_Init(object sender, EventArgs e)
        {
            this.Load += (send, args) => Invoke(PageLoad);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //this.AsyncMode = true;
        }
    }
}