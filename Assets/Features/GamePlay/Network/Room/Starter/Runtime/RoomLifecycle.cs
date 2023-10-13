using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using GamePlay.Network.Room.Entities.Factory;
using GamePlay.Network.Room.EventLoops.Runtime;
using Global.Network.Handlers.ClientHandler.Runtime;

namespace GamePlay.Network.Room.Starter.Runtime
{   
    public class RoomLifecycle : IScopeAwakeAsyncListener, IScopeDisableAsyncListener
    {
        public RoomLifecycle(
            IRoomProvider roomProvider,
            IClientProvider clientProvider,
            ISceneEntityFactory sceneEntityFactory,
            IGamePlayNetworkCallbacks callbacks)
        {
            _roomProvider = roomProvider;
            _clientProvider = clientProvider;
            _sceneEntityFactory = sceneEntityFactory;
            _callbacks = callbacks;
        }
        
        private readonly IRoomProvider _roomProvider;
        private readonly IClientProvider _clientProvider;
        private readonly ISceneEntityFactory _sceneEntityFactory;
        private readonly IGamePlayNetworkCallbacks _callbacks;

        public async UniTask OnAwakeAsync()
        {
            var flagEntityTask = _sceneEntityFactory.Create();

            await _callbacks.InvokeRegisterCallbacks(_clientProvider.Client.Event);
            var entityCreation =  _callbacks.InvokeSceneEntityCreation();
            
            _roomProvider.SceneLoaded();
            
            await flagEntityTask;
            await entityCreation;
            
            await _callbacks.InvokeAwakeCallbacks();
        }

        public async UniTask OnDisabledAsync()
        {
            await _callbacks.InvokeDestroyCallbacks();
        }
    }
}