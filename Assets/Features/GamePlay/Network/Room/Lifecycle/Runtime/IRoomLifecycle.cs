using Ragon.Client;

namespace GamePlay.Network.Room.Lifecycle.Runtime
{
    public interface IRoomLifecycle
    {
        void SceneLoaded();
        void SendEntity(RagonEntity entity, IRagonPayload payload = null);
    }
}