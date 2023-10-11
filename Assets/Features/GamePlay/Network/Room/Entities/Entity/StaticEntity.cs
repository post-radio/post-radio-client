using System;
using Cysharp.Threading.Tasks;
using GamePlay.Network.Room.Entities.Factory;
using Ragon.Client;

namespace GamePlay.Network.Room.Entities.Entity
{
    public class StaticEntity : IStaticEntity
    {
        public StaticEntity(ISceneEntityFactory entityFactory)
        {
            _entityFactory = entityFactory;
        }

        private readonly ISceneEntityFactory _entityFactory;

        private RagonEntity _entity;
        
        public async UniTask Create()
        {
            _entity = await _entityFactory.Create();
        }
        
        public async UniTask Create(params RagonProperty[] properties)
        {
            _entity = await _entityFactory.Create(properties);
        }
        
        public void ListenEvent<TEvent>(Action<RagonPlayer, TEvent> callback) where TEvent : IRagonEvent, new()
        {
            _entity.OnEvent(callback);
        }

        public void ReplicateEvent<TEvent>(TEvent data) where TEvent : IRagonEvent, new()
        {
            _entity.ReplicateEvent(data);
        }
    }
}