using Ragon.Client;

namespace GamePlay.Network.Objects.Factories.Runtime
{
    public interface IDynamicEntityFactory
    {
        RagonEntity Create(ushort type);
    }
}