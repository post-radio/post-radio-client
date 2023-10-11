using Ragon.Client;
using Ragon.Protocol;

namespace Global.Network.Handlers.ClientHandler.Runtime
{
    public class RoomProvider : IRoomProvider
    {
        public RoomProvider(IClientProvider clientProvider)
        {
            _clientProvider = clientProvider;
        }

        private readonly IClientProvider _clientProvider;

        private RagonRoom _room => _clientProvider.Client.Room;

        public string Id => _room.Id;
        public bool IsOwner => _room.Local.IsRoomOwner;
        public RagonRoom Room => _room;
        public RagonPlayer LocalPlayer => _room.Local;

        public void SceneLoaded()
        {
            _room.SceneLoaded();
        }

        public void SendEntity(RagonEntity entity, IRagonPayload payload = null)
        {
            var buffer = new RagonBuffer();
            RagonPayload rawPayload = null;

            if (payload != null)
            {
                payload.Serialize(buffer);

                rawPayload = new RagonPayload(buffer.WriteOffset);
                rawPayload.Read(buffer);

                entity.AttachPayload(rawPayload);
            }

            _room.CreateEntity(entity, rawPayload);
        }
    }
}