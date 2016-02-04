using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Escyug.Nosology.MVP.UI.WebApp.pages.shared
{
    public partial class _Main : System.Web.UI.MasterPage
    {
        public _Main()
        {
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [System.Web.Services.WebMethod]
        public static string GetCurrentTime()
        {
            return "Hello " + "wat" + Environment.NewLine + "The Current Time is: "
                + DateTime.Now.ToString();
        }
    }
}