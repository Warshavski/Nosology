using System;
using System.Threading.Tasks;

namespace Escyug.Nosology.Web.App.Forms
{
    internal sealed class Invoker
    {
        public static void Invoke(Action action)
        {
            if (action != null)
                action.Invoke();
        }

        public static async Task InvokeAsync(Func<Task> func)
        {
            if (func != null)
                await func.Invoke();
        }
    }
}