using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Common.Routes;
using Common.Architecture.Scopes.Runtime.Callbacks;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Common.Architecture.Scopes.Common.DefaultCallbacks
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "DefaultCallbacks", menuName = ScopesRoutes.Root + "DefaultCallbacks")]
    public class DefaultCallbacksServiceFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var callbacks = new DefaultCallbacksFactory();
            callbacks.AddCallbacks(utils.Callbacks, utils.Data);
        }
    }
}