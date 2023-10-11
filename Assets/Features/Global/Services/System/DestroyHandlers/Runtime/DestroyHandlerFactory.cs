using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Global.System.DestroyHandlers.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.System.DestroyHandlers.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = DestroyHandlerRoutes.ServiceName,
        menuName = DestroyHandlerRoutes.ServicePath)]
    public class DestroyHandlerFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private DestroyHandler _prefab;
        
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var destroyHandler = Instantiate(_prefab);

            services.RegisterComponent(destroyHandler)
                .WithParameter(utils.Callbacks)
                .AsCallbackListener();
            
            utils.Binder.MoveToModules(destroyHandler);
        }
    }
}