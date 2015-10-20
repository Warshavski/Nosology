using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using WebNosology.Presentation.Views;

namespace WebNosology.UI.WebApp.pages
{
    public partial class main : System.Web.UI.Page, IMainView
    {
        public main()
        { 
            
        }

        private void Invoke(Action action)
        {
            if (action != null)
                action.Invoke();
        }

        #region Члены IMainView

        public string UserName
        {
            set 
            { 
                
            }
        }

        public string UserLevel
        {
            set 
            {
                
            }
        }

        #endregion
    
        /*
        protected void Signout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("pages/login.aspx");
        }
        */

        protected void Page_Init(object sender, EventArgs e)
        {
            this.signOutLink.ServerClick += (send, args) =>
                {
                    FormsAuthentication.SignOut();
                    Response.Redirect("pages/login.aspx");
                };
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string[] splitedString = Context.User.Identity.Name.Split('#');
            
            this.userName.Text = splitedString[0];
            this.userLevel.Text = string.Format("Уровень : {0}", splitedString[1]);
        }

    }
}
