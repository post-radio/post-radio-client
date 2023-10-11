using Internal.Services.Loggers.Runtime;

namespace Global.Network.Connection.Logs
{
    public class ConnectionLogger
    {
        public ConnectionLogger(ILogger logger, ConnectionLogSettings settings)
        {
            _logger = logger;
            _settings = settings;
        }

        private readonly ILogger _logger;
        private readonly ConnectionLogSettings _settings;

        public void OnConnectionAttempt(string address, string protocol, ushort port)
        {
            if (_settings.IsAvailable(ConnectionLogType.ConnectionAttempt) == false)
                return;
            
            _logger.Log($"Connection attempt to: {address}:{port} via {protocol}", _settings.LogParameters);
        }

        public void OnConnectionFailed(string message)
        {
            if (_settings.IsAvailable(ConnectionLogType.ConnectionFailed) == false)
                return;
            
            _logger.Log($"Connection failed: {message}", _settings.LogParameters);
        }
        
        public void OnConnectionSuccess()
        {
            if (_settings.IsAvailable(ConnectionLogType.ConnectionSuccess) == false)
                return;
            
            _logger.Log("Connection success", _settings.LogParameters);
        }

        public void OnAuthorizationAttempt(string name)
        {
            if (_settings.IsAvailable(ConnectionLogType.AuthorizationAttempt) == false)
                return;
            
            _logger.Log($"On authorization attempt with name: {name}", _settings.LogParameters);
        }
        
        public void OnAuthorizationFailed(string message)
        {
            if (_settings.IsAvailable(ConnectionLogType.AuthorizationFailed) == false)
                return;
            
            _logger.Log($"Authorization failed: {message}", _settings.LogParameters);
        }
        
        public void OnAuthorizationSuccess()
        {
            if (_settings.IsAvailable(ConnectionLogType.AuthorizationSuccess) == false)
                return;
            
            _logger.Log("Authorization success", _settings.LogParameters);
        }
    }
}