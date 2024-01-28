using System;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using GamePlay.Network.Room.Entities.Factory;
using GamePlay.Network.Room.EventLoops.Runtime;
using Global.Network.Handlers.ClientHandler.Runtime;
using Global.System.Updaters.Runtime.Abstract;
using Ragon.Client;
using Ragon.Protocol;

namespace Features.GamePlay.Network.Room.Lifecycle.Runtime
{   
    public class RoomLifecycle :
        IScopeAwakeAsyncListener,
        IScopeDisableAsyncListener,
        IRoomLifecycle,
        IRoomProvider,
        IUpdatable
    {
        public RoomLifecycle(
            IClientProvider clientProvider,
            ISceneEntityFactory sceneEntityFactory,
            IGamePlayNetworkCallbacks callbacks,
            IUpdater updater)
        {
            _clientProvider = clientProvider;
            _sceneEntityFactory = sceneEntityFactory;
            _callbacks = callbacks;
            _updater = updater;
        }
        
        private readonly IClientProvider _clientProvider;
        private readonly ISceneEntityFactory _sceneEntityFactory;
        private readonly IGamePlayNetworkCallbacks _callbacks;
        private readonly IUpdater _updater;

        private bool _isOwnerEventInvoked;
        
        public RagonRoom Room => _clientProvider.Client.Room;
        public bool IsOwner => Room.Local.IsRoomOwner;
        public RagonPlayer LocalPlayer => Room.Local;
        
        public event Action BecameOwner;
        
        public async UniTask OnAwakeAsync()
        {
            var flagEntityTask = _sceneEntityFactory.Create();

            await _callbacks.InvokeRegisterCallbacks(_clientProvider.Client.Event);

            var entityCreation =  _callbacks.InvokeSceneEntityCreation();

            await UniTask.Yield();

            SceneLoaded();
            
            await flagEntityTask;
            await entityCreation;

            await _callbacks.InvokeAwakeCallbacks();
            _isOwnerEventInvoked = IsOwner;
            _updater.Add(this);
        }

        public async UniTask OnDisabledAsync()
        {
            _updater.Remove(this);
            await _callbacks.InvokeDestroyCallbacks();
        }

        public void SceneLoaded()
        {
            Room.SceneLoaded();
        }

        public void SendEntity(RagonEntity entity, IRagonPayload payload = null)
        {
            var buffer = new RagonBuffer();
            RagonPayload rawPayload = null;

            if (payload != null)
            {
                payload.Serialize(buffer);

                rawPayload = new RagonPayload(buffer.WriteOffset);
                rawPayload.Read(buffer);    
                
                entity.Prepare(_clientProvider.Client, 0, entity.Type, true, Room.Local, rawPayload);
            }

            Room.CreateEntity(entity, rawPayload);
        }

        public void OnUpdate(float delta)
        {
            if (IsOwner == false)
            {
                _isOwnerEventInvoked = false;
                return;
            }

            if (_isOwnerEventInvoked == true)
                return;

            _isOwnerEventInvoked = true;
            BecameOwner?.Invoke();
        }
    }
}