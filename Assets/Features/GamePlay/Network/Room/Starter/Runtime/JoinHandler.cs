using Cysharp.Threading.Tasks;
using Global.Network.Handlers.ClientHandler.Runtime;
using Ragon.Client;

namespace GamePlay.Network.Room.Starter.Runtime
{
    public class JoinHandler : IRagonJoinListener
    {
        public JoinHandler(
            IRoomProvider roomProvider,
            IClientProvider clientProvider)
        {
            _roomProvider = roomProvider;
            _clientProvider = clientProvider;

            _completion = new UniTaskCompletionSource();
        }

        private readonly UniTaskCompletionSource _completion;
        private readonly IRoomProvider _roomProvider;
        private readonly IClientProvider _clientProvider;

        public async UniTask ProcessJoin()
        {
            var client = _clientProvider.Client;

            client.AddListener(this);
            await _completion.Task;
            await UniTask.Yield();
            client.RemoveListener(this);

            await UniTask.Yield();
        }

        public void OnJoined(RagonClient client)
        {
            _completion.TrySetResult();
        }
    }
}