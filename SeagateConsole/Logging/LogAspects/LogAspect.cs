using PostSharp.Aspects;
using PostSharp.Extensibility;
using PostSharp.Serialization;
using SeagateConsole.Logging.Log4Net;
using System.Reflection;

namespace SeagateConsole.Logging.LogAspects
{
    [PSerializable]
    [MulticastAttributeUsage(MulticastTargets.Method, TargetMemberAttributes = MulticastAttributes.Instance)]
    // Bu, AttributeTargets.Class ve AttributeTargets.
    // Method hedeflerine izin veren, miras alınabilir ve
    // birden fazla kullanımı mümkün kılan bir örnek olarak tanımlanmıştır.
    // Instance yazıldığından dolayı Constructor hariç tüm methodlara uygulanır.
    public class LogAspect : OnMethodBoundaryAspect
    {
        private Type _type;
        private LoggerService _loggerService;

        public LogAspect(Type type)
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
        public override void OnEntry(MethodExecutionArgs args)
        {
            if (!_loggerService.IsInfoEnabled())
            {
                return;
            }
            var logParameters = args.Method.GetParameters().Select((t, i) => new LogParameter
            {
                Name = t.Name,
                Type = t.ParameterType.Name,
                Value = args.Arguments.GetArgument(i)
            }).ToList();
            var logDetail = new LogDetail
            {
                FullName = args.Method.DeclaringType == null ? null : args.Method.DeclaringType.Name,
                MethodName = args.Method.Name,
                Parameters = logParameters
            };
            _loggerService.Info(logDetail);
        }
    }
}
