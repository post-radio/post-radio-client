using Internal.Services.Loggers.Runtime;

namespace Global.Network.Session.Logs
{
    public class SessionLogger
    {
        public SessionLogger(ILogger logger, SessionLogSettings settings)
        {
            _logger = logger;
            _settings = settings;
        }

        private readonly ILogger _logger;
        private readonly SessionLogSettings _settings;

        public void OnCreateAttempt(string id)
        {
            if (_settings.IsAvailable(SessionLogType.CreateAttempt) == false)
                return;

            _logger.Log($"Room creation attempt with id: {id}", _settings.LogParameters);
        }
        
        public void OnCreateFail(string message)
        {
            if (_settings.IsAvailable(SessionLogType.CreateFail) == false)
                return;

            _logger.Log($"Room creation failed: {message}", _settings.LogParameters);
        }
        
        public void OnCreateSuccess()
        {
            if (_settings.IsAvailable(SessionLogType.CreateSuccess) == false)
                return;

            _logger.Log("Room creation succeed", _settings.LogParameters);
        }
        
        public void OnJoinAttempt(string id)
        {
            if (_settings.IsAvailable(SessionLogType.JoinAttempt) == false)
                return;

            _logger.Log($"Room join attempt with id: {id}", _settings.LogParameters);
        }
        
        public void OnJoinFail(string message)
        {
            if (_settings.IsAvailable(SessionLogType.JoinFail) == false)
                return;

            _logger.Log($"Room join failed: {message}", _settings.LogParameters);
        }
        
        public void OnJoinSuccess()
        {
            if (_settings.IsAvailable(SessionLogType.JoinSuccess) == false)
                return;

            _logger.Log("Room join succeed", _settings.LogParameters);
        }
        
        public void OnLeaveAttempt(string id)
        {
            if (_settings.IsAvailable(SessionLogType.LeaveAttempt) == false)
                return;

            _logger.Log($"Room leave attempt with id: {id}", _settings.LogParameters);
        }
        
        public void OnLeaveFail(string message)
        {
            if (_settings.IsAvailable(SessionLogType.LeaveFail) == false)
                return;

            _logger.Log($"Room leave failed: {message}", _settings.LogParameters);
        }
        
        public void OnLeaveSuccess()
        {
            if (_settings.IsAvailable(SessionLogType.LeaveSuccess) == false)
                return;

            _logger.Log("Room leave succeed", _settings.LogParameters);
        }
    }
}