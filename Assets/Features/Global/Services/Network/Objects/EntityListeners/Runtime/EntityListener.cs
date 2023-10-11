using System;
using Global.Network.Objects.Factories.Abstract;
using Ragon.Client;

namespace Global.Network.Objects.EntityListeners.Runtime
{
    public class EntityListener : IEntityListener
    {
        private readonly ObjectIdGenerator _idGenerator = new();
        
        public event Action<EntityPrefabId, RagonEntity> EntityReceived;

        public void OnEntityCreated(RagonEntity entity)
        {
            var id = _idGenerator.GetPrefabId(entity.Type);
            
            EntityReceived?.Invoke(id, entity);
        }
    }
}