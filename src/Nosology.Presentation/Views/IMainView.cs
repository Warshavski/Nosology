using System;
using System.Threading.Tasks;

using Escyug.Nosology.Presentation.Common;

namespace Escyug.Nosology.Presentation.Views
{
    public interface IMainView : IView
    {
        event Func<Task> PageLoadAsync;
        string TextBlock { set; }
    }
}
