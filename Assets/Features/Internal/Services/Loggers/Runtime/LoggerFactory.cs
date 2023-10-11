using Internal.Abstract;
using Internal.Services.Loggers.Common;
using Internal.Services.Options.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

namespace Internal.Services.Loggers.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LoggerRoutes.ServiceName,
        menuName = LoggerRoutes.ServicePath)]
    public class LoggerFactory : ScriptableObject, IInternalServiceFactory
    {
        public void Create(IOptions options, IContainerBuilder builder)
        {
            builder.Register<Logger>(Lifetime.Singleton)
                .As<ILogger>();
        }
    }
}