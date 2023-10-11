using Ragon.Client;

namespace Global.Network.Handlers.SceneCollectors.Runtime
{
    public interface INetworkSceneCollector
    {
        void AddEntity(RagonEntity entity);
        RagonEntity[] Collect();
    }
}