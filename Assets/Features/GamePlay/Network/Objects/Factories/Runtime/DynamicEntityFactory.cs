using Ragon.Client;

namespace GamePlay.Network.Objects.Factories.Runtime
{
    public class DynamicEntityFactory : IDynamicEntityFactory
    {
        public RagonEntity Create(ushort type)
        {
            var entity = new RagonEntity(type);
        
            return entity;
        }
    }
}