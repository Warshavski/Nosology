using System;

namespace Escyug.Nosology.Web.App
{
    internal sealed class Invoker
    {
        public static void Invoke(Action action)
        {
            if (action != null)
                action.Invoke();
        }
    }
}