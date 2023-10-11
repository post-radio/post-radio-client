using Cysharp.Threading.Tasks;

namespace GamePlay.Network.Room.EventLoops.Runtime
{
    public interface INetworkSetupListener
    {
        UniTask OnNetworkSetupAsync();
    }
}