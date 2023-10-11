namespace Global.Network.Objects.Factories.Abstract
{
    public readonly struct EntityPrefabId
    {
        public EntityPrefabId(int factoryId, int objectId)
        {
            FactoryId = factoryId;
            ObjectId = objectId;
        }

        public readonly int FactoryId;
        public readonly int ObjectId;
    }
}