using Global.Network.Objects.Factories.Abstract;

namespace GamePlay.Network.Objects.Factories.Registry
{
    public interface INetworkFactoriesRegistry
    {
        void Register(IEntityFactory factory);
        void Unregister(IEntityFactory factory);
    }
}