using System;
using Cysharp.Threading.Tasks;
using Global.Network.Handlers.ClientHandler.Runtime;
using Global.Network.Session.Logs;

namespace Global.Network.Session.Runtime.Create
{
    public class SessionCreate : ISessionCreate
    {
        public SessionCreate(IClientProvider clientProvider, SessionLogger logger)
        {
            _clientProvider = clientProvider;
            _logger = logger;
        }
        
        private readonly IClientProvider _clientProvider;
        private readonly SessionLogger _logger;

        public async UniTask<SessionCreateResult> Create()
        {
            var attempt = new CreateAttempt(_clientProvider.Client, _logger);

            var id = Guid.NewGuid().ToString();
            id = id.Substring(0, 8);
            return await attempt.Create(id);
        }
    }
}