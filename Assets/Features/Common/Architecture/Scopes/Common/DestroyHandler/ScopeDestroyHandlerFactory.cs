using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Common.Routes;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Common.Architecture.Scopes.Common.DestroyHandler
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "ScopeDestroyHandler", menuName = ScopesRoutes.Root + "ScopeDestroyHandler")]
    public class ScopeDestroyHandlerFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private ScopeDestroyHandler _prefab;
        
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var handler = Instantiate(_prefab);
            handler.name = "ScopeDestroyHandler";

            utils.Binder.MoveToModules(handler);
            handler.Construct(utils.Callbacks);
        }
    }
}