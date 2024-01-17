using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Global.Backend.Abstract;
using Global.Backend.Common;
using Global.Backend.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Backend.Runtime
{

    [InlineEditor]
    [CreateAssetMenu(fileName = BackendRoutes.ServiceName, menuName = BackendRoutes.ServicePath)]
    public class BackendFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private BackendLogSettings _logSettings;
        
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<BackendLogger>()
                .WithParameter(_logSettings);
            
            services.Register<BackendClient>()
                .As<IBackendClient>()
                .AsCallbackListener();
        }
    }
}