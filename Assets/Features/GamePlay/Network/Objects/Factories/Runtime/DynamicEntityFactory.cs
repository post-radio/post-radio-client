﻿using Cysharp.Threading.Tasks;
using Global.Network.Handlers.ClientHandler.Runtime;
using Ragon.Client;

namespace GamePlay.Network.Objects.Factories.Runtime
{
    public class DynamicEntityFactory : IDynamicEntityFactory
    {
        public DynamicEntityFactory(IRoomProvider roomProvider)
        {
            _roomProvider = roomProvider;
        }
        
        private readonly IRoomProvider _roomProvider;

        public RagonEntity Create(ushort type)
        {
            var entity = new RagonEntity(type);
        
            return entity;
        }

        public async UniTask Send(RagonEntity entity, IRagonPayload payload)
        {
            var completion = new UniTaskCompletionSource();

            void OnAttached(RagonEntity attachedEntity)
            {
                completion.TrySetResult();
            }

            entity.Attached += OnAttached;
            
            _roomProvider.SendEntity(entity, payload);
            
            await completion.Task;
            
            entity.Attached -= OnAttached;
        }
    }
}