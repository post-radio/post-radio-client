using Cysharp.Threading.Tasks;
using Global.Network.Session.Logs;
using Ragon.Client;
using Ragon.Protocol;

namespace Global.Network.Session.Runtime.Join
{
        public class JoinRandomAttempt : IRagonFailedListener, IRagonSceneRequestListener
        {
            public JoinRandomAttempt(RagonClient client, SessionLogger logger)
            {
                _client = client;
                _logger = logger;
            }
        
            private readonly RagonClient _client;
            private readonly SessionLogger _logger;

            private readonly UniTaskCompletionSource<SessionJoinResult> _completion = new();

            public async UniTask<SessionJoinResult> JoinRandom()
            {   
                Listen();
            
                _logger.OnJoinAttempt("Random");

                var parameters = new RagonRoomParameters
                {
                    Min = 0,
                    Max = 20,
                    Scene = "Level"
                };
                
                _client.Session.CreateOrJoin(parameters);
                var result = await _completion.Task;

                await UniTask.Yield();

                Unlisten();
                
                return result;
            }
        
            public void OnFailed(RagonClient client, string message)
            {
                _logger.OnJoinFail(message);
                _completion.TrySetResult(new SessionJoinResult(SessionJoinResultType.Fail, message));
            }
        
            private void Listen()
            {
                _client.AddListener((IRagonSceneRequestListener)this);
                _client.AddListener((IRagonFailedListener)this);
            }

            private void Unlisten()
            {
                _client.RemoveListener((IRagonSceneRequestListener)this);
                _client.RemoveListener((IRagonFailedListener)this);
            }

            public void OnRequestScene(RagonClient client, string sceneName)
            {
                _logger.OnJoinSuccess();
                _completion.TrySetResult(new SessionJoinResult(SessionJoinResultType.Success));
            }
        }
}