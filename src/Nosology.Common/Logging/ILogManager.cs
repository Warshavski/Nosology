using System;

using log4net;

namespace Escyug.Nosology.Common.Logging
{
    /*
     * interface for DI framework
     * we need to push dependencies up to controller, 
     * and not rely on specific static properties or methods
     */
    public interface ILogManager
    {
        ILog GetLog(Type typeAssociatedWithRequestedLog);
    }
}
