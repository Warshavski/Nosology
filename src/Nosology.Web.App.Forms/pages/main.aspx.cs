using System;
using System.Threading.Tasks;

using Escyug.Nosology.Presentation.Views;

namespace Escyug.Nosology.Web.App.Forms.pages
{
    public partial class main : PageBase<IMainView>, IMainView
    {
        protected override IMainView GetView() { return this; }

        public event Func<Task> PageLoadAsync;

        // ewwww... (Task.. void...) WTF?!
        protected async void Page_Load(object sender, EventArgs e)
        {
            await Invoker.InvokeAsync(PageLoadAsync);
        }

        public string TextBlock
        {
            set { contentLiteral.Text = value; }
        }
    }
}