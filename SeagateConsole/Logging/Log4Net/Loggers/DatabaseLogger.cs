using log4net;
using SeagateConsole.Logging.Log4Net;

namespace NebulaLearning.Core.Net4x.CrossCuttingConserns.Logging.Log4Net.Loggers
{
    public class DatabaseLogger : LoggerService
    {
        //public DatabaseLogger(ILog log) : base(log)
        public DatabaseLogger() : base(LogManager.GetLogger("DatabaseLogger"))
        {
        }
    }
}
