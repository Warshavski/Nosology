using System;

using log4net;

namespace Escyug.Nosology.Common.Logging
{
    public sealed class LogManagerAdapter : ILogManager
    {
        public ILog GetLog(Type typeAssociatedWithRequestedLog)
        {
            var log = LogManager.GetLogger(typeAssociatedWithRequestedLog);
            return log;
        }
    }
}
