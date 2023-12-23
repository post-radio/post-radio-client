using Internal.Services.Loggers.Runtime;

namespace GamePlay.Network.Messaging.Events.Logs
{
    public class NetworkEventsLogger
    {
        public NetworkEventsLogger(ILogger logger, NetworkEventsLogSettings settings)
        {
            _logger = logger;
            _settings = settings;
        }

        private readonly ILogger _logger;
        private readonly NetworkEventsLogSettings _settings;

        public void OnRouteAdded<TEvent>()
        {
            if (_settings.IsAvailable(NetworkEventsLogType.AddRoute) == false)
                return;

            _logger.Log($"On event route for type {typeof(TEvent)} added", _settings.LogParameters);
        }
        
        public void OnEventSent<TEvent>()
        {
            if (_settings.IsAvailable(NetworkEventsLogType.EventSent) == false)
                return;

            _logger.Log($"On event sent for type {typeof(TEvent)}", _settings.LogParameters);
        }
        
        public void OnEventReceived<TEvent>()
        {
            if (_settings.IsAvailable(NetworkEventsLogType.EventReceived) == false)
                return;

            _logger.Log($"On event received for type {typeof(TEvent)}", _settings.LogParameters);
        }
    }
}