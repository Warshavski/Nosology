using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Escyug.Nosology.MVP.UI.WebApp.pages
{
	public partial class main : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            this.AsyncMode = true;

            string errorMessage = "SERVER ERROR";
            string path = string.Format("{0}\\{1}", HttpRuntime.AppDomainAppPath, "App_Data\\main.txt");
            
            StringBuilder content = new StringBuilder();

            StreamReader reader = null;
            try
            {
                using (reader = new StreamReader(path, Encoding.GetEncoding(1251)))
                {
                    while (!reader.EndOfStream)
                        content.Append(reader.ReadToEnd());
                }
            }
            catch (IOException)
            {
                content.Append(errorMessage);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }

            contentLiteral.Text = content.ToString();
		}
	}
}