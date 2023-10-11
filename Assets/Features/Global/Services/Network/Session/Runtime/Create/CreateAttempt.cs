using Cysharp.Threading.Tasks;
using Global.Network.Session.Logs;
using Ragon.Client;

namespace Global.Network.Session.Runtime.Create
{
    public class CreateAttempt : IRagonFailedListener, IRagonSceneRequestListener
    {
        public CreateAttempt(RagonClient client, SessionLogger logger)
        {
            _client = client;
            _logger = logger;
        }
        
        private readonly RagonClient _client;
        private readonly SessionLogger _logger;

        private readonly UniTaskCompletionSource<SessionCreateResult> _completion = new();

        public async UniTask<SessionCreateResult> Create(string id)
        {
            Listen();
            
            _logger.OnCreateAttempt(id);
            _client.Session.Create(id, "", 1, 16);
            var result = await _completion.Task;

            await UniTask.Yield();

            Unlisten();

            return result;
        }
        
        public void OnFailed(RagonClient client, string message)
        {
            _logger.OnCreateFail(message);
            _completion.TrySetResult(new SessionCreateResult(SessionCreateResultType.Success, message));
        }
        
        private void Listen()
        {
            _client.AddListener((IRagonFailedListener)this);
        }

        private void Unlisten()
        {
            _client.RemoveListener((IRagonFailedListener)this);
        }

        public void OnRequestScene(RagonClient client, string sceneName)
        {
            _logger.OnCreateSuccess();
            _completion.TrySetResult(new SessionCreateResult(SessionCreateResultType.Success));
        }
    }
}