using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Network.Common.Paths;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Network.Room.EventLoops.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "GamePlayNetworkEvents", menuName = GamePlayNetworkAssetsPaths.Root + "Events")]
    public class NetworkEventsLoopFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var callbacks = new NetworkCallbacksFactory();
            utils.Callbacks.AddGenericCallbackRegister(callbacks);

            services.RegisterInstance(callbacks)
                .As<IGamePlayNetworkCallbacks>();

            services.Inject(callbacks);
        }
    }
}