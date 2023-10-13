using Cysharp.Threading.Tasks;
using GamePlay.Network.Room.Entities.Factory;

namespace GamePlay.Network.Room.EventLoops.Runtime
{
    public interface INetworkSceneEntityCreationListener
    {
        UniTask OnSceneEntityCreation(ISceneEntityFactory factory);
    }
}