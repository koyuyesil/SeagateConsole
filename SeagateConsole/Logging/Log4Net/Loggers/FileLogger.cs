using log4net;
using SeagateConsole.Logging.Log4Net;

namespace NebulaLearning.Core.Net4x.CrossCuttingConserns.Logging.Log4Net.Loggers
{
    // NOT log4net Çalışabilmesi için kullanıldığı yerde
    // yerel Web.config ve harici log4net.config
    // dosyalarında modifikasyona ihtiyac duyar. (MvcWebUI)
    public class FileLogger : LoggerService
    {
        public FileLogger() : base(LogManager.GetLogger("JsonFileLogger"))
        {
        }
    }
}
