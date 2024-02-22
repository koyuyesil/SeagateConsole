using log4net.Core;
using PostSharp.Serialization;

namespace SeagateConsole.Logging.Log4Net
{
    [PSerializable]
    public class SerializableLogEvent
    {
        LoggingEvent _loggingEvent;

        public SerializableLogEvent(LoggingEvent loggingEvent)
        {
            _loggingEvent = loggingEvent;
        }
        public string UserName => _loggingEvent.UserName;
        public object MessageObect => _loggingEvent.MessageObject;
    }
}
