using PostSharp.Aspects;
using PostSharp.Serialization;
using SeagateConsole.Logging.Log4Net;
using System.Reflection;

namespace NebulaLearning.Core.Net4x.Aspects.PostSharp.LogAspects
{
    [PSerializable]
    public class LogExceptionAspect : OnExceptionAspect
    {
        private Type _type;
        private LoggerService _loggerService;

        public LogExceptionAspect(Type type)
        {
            _type = type;
        }
        public override void RuntimeInitialize(MethodBase method)
        {
            if (_type.BaseType != typeof(LoggerService))
            {
                throw new Exception("Wrong logger type");
            }
            _loggerService = (LoggerService)Activator.CreateInstance(_type);
            base.RuntimeInitialize(method);
        }
        public override void OnException(MethodExecutionArgs args)
        {
            if (_loggerService!=null)
            {
                _loggerService.Error(args.Exception);
            }
        }
    }
}
