using UnityEngine;

namespace Global.Network.Objects.Factories.Abstract
{
    public class ObjectIdGenerator
    {
        private const int _shift = 100;

        public ushort Generate(int factoryId, int objectId)
        {
            var id = (ushort)(factoryId * _shift + objectId);

            return id;
        }

        public EntityPrefabId GetPrefabId(int id)
        {
            var factoryId = Mathf.FloorToInt(id / (float)_shift);
            var multipliedFactoryId = factoryId * _shift;
            var objectId = id - multipliedFactoryId;

            return new EntityPrefabId(factoryId, objectId);
        }
    }
}