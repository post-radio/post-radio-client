using Ragon.Client;

namespace Global.Network.Handlers.ClientHandler.Runtime
{
    public interface IRoomProvider
    {
        public string Id { get; }
        public bool IsOwner { get; }
        RagonRoom Room { get; }
        RagonPlayer LocalPlayer { get; }

        void SceneLoaded();
        void SendEntity(RagonEntity entity, IRagonPayload payload = null);
    }
}