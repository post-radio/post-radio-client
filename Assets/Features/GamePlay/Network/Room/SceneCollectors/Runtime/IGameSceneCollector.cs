using Global.Network.Handlers.SceneCollectors.Runtime;

namespace GamePlay.Network.Room.SceneCollectors.Runtime
{
    public interface IGameSceneCollector : INetworkSceneCollector
    {
        bool IsCollected { get; }
    }
}