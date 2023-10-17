using Cysharp.Threading.Tasks;
using Global.Network.Handlers.ClientHandler.Runtime;
using Global.Network.Session.Logs;

namespace Global.Network.Session.Runtime.Join
{
    public class SessionJoin : ISessionJoin
    {
        public SessionJoin(IClientProvider clientProvider, SessionLogger logger)
        {
            _clientProvider = clientProvider;
            _logger = logger;
        }
        
        private readonly IClientProvider _clientProvider;
        private readonly SessionLogger _logger;

        public async UniTask<SessionJoinResult> Join(string id)
        {
            var attempt = new JoinAttempt(_clientProvider.Client, _logger);

            return await attempt.Join(id);
        }

        public async UniTask<SessionJoinResult> JoinRandom()
        {
            var attempt = new JoinRandomAttempt(_clientProvider.Client, _logger);

            return await attempt.JoinRandom();
        }
    }
}