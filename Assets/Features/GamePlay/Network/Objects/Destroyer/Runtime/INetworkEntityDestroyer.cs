using GamePlay.Network.Objects.Definition;

namespace GamePlay.Network.Objects.Destroyer.Runtime
{
    public interface INetworkEntityDestroyer
    {
        void Destroy(INetworkObject networkObject);
    }
}