using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Global.System.ApplicationProxies.Common;
using Global.System.ApplicationProxies.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.System.ApplicationProxies.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ApplicationProxyRoutes.ServiceName,
        menuName = ApplicationProxyRoutes.ServicePath)]
    public class ApplicationProxyFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [Indent] private ApplicationProxyLogSettings _logSettings;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<ApplicationProxyLogger>()
                .WithParameter(_logSettings);

            services.Register<ApplicationProxy>()
                .As<IScreen>()
                .As<IApplicationFlow>();
        }
    }
}