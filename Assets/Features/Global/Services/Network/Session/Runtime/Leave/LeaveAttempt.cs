using Cysharp.Threading.Tasks;
using Global.Network.Session.Logs;
using Ragon.Client;

namespace Global.Network.Session.Runtime.Leave
{
    public class LeaveAttempt : IRagonLeftListener, IRagonFailedListener
    {
        public LeaveAttempt(RagonClient client, SessionLogger logger)
        {
            _client = client;
            _logger = logger;
        }
        
        private readonly RagonClient _client;
        private readonly SessionLogger _logger;

        private readonly UniTaskCompletionSource<SessionLeaveResult> _completion = new();

        public async UniTask<SessionLeaveResult> Join(string id)
        {
            Listen();
            
            _logger.OnJoinAttempt(id);

            var result = await _completion.Task;

            return result;
        }
        
        public void OnLeft(RagonClient client)
        {
            _logger.OnJoinSuccess();
            _completion.TrySetResult(SessionLeaveResult.Success);
        }

        public void OnFailed(RagonClient client, string message)
        {
            _logger.OnJoinFail(message);
            _completion.TrySetResult(SessionLeaveResult.Fail);
        }
        
        private void Listen()
        {
            _client.AddListener((IRagonLeftListener)this);
            _client.AddListener((IRagonFailedListener)this);
        }

        private void Unlisten()
        {
            _client.RemoveListener((IRagonLeftListener)this);
            _client.RemoveListener((IRagonFailedListener)this);
        }
    }
}