using Cysharp.Threading.Tasks;

namespace GamePlay.Network.Room.EventLoops.Runtime
{   
    public interface INetworkDestroyListener
    {
        UniTask OnNetworkDestroy();
    }
}