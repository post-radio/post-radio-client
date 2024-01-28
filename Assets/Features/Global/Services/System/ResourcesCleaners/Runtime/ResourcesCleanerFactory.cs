using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Global.System.ResourcesCleaners.Common;
using Global.System.ResourcesCleaners.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.System.ResourcesCleaners.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ResourcesCleanerRouter.ServiceName,
        menuName = ResourcesCleanerRouter.ServicePath)]
    public class ResourcesCleanerFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [Indent] private ResourcesCleanerLogSettings _logSettings;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<ResourcesCleanerLogger>().WithParameter(_logSettings);

            services.Register<ResourcesCleaner>()
                .As<IResourcesCleaner>();
        }
    }
}