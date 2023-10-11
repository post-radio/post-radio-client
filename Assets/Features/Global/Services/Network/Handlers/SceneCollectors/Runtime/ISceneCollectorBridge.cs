using Ragon.Client;

namespace Global.Network.Handlers.SceneCollectors.Runtime
{
    public interface ISceneCollectorBridge : IRagonSceneCollector
    {
        void AddCollector(INetworkSceneCollector collector);
    }
}