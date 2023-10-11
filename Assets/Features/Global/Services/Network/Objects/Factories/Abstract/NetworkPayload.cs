using Ragon.Protocol;

namespace Global.Network.Objects.Factories.Abstract
{
    public class NetworkPayload
    {
        public NetworkPayload(int factoryId, int objectId)
        {
            _id = new EntityPrefabId(factoryId, objectId);
        }

        public NetworkPayload()
        {
        }

        private EntityPrefabId _id;

        public EntityPrefabId Id => _id;

        public void Serialize(RagonBuffer buffer)
        {
            buffer.WriteInt(_id.FactoryId, 0, 512);
            buffer.WriteInt(_id.ObjectId, 0, 512);

            OnSerialize(buffer);
        }

        public void Deserialize(RagonBuffer buffer)
        {
            var factoryId = buffer.ReadInt(0, 512);
            var objectId = buffer.ReadInt(0, 512);

            _id = new EntityPrefabId(factoryId, objectId);

            OnDeserialize(buffer);
        }

        protected virtual void OnSerialize(RagonBuffer buffer)
        {
        }

        protected virtual void OnDeserialize(RagonBuffer buffer)
        {
        }
    }
}