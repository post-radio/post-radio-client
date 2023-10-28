﻿using Internal.Services.Loggers.Runtime;

namespace Global.System.MessageBrokers.Logs
{
    public class MessageBrokerLogger
    {
        public MessageBrokerLogger(ILogger logger, MessageBrokerLogSettings settings)
        {
            _logger = logger;
            _settings = settings;
        }

        private readonly ILogger _logger;
        private readonly MessageBrokerLogSettings _settings;

        public void OnListen<T>()
        {
            if (_settings.IsAvailable(MessageBrokerLogType.Listen) == false)
                return;

            _logger.Log($"{typeof(T)} is listened.", _settings.LogParameters);
        }

        public void OnPublish<T>()
        {
            if (_settings.IsAvailable(MessageBrokerLogType.Publish) == false)
                return;

            _logger.Log($"{typeof(T)} is published.", _settings.LogParameters);
        }
        
        public void OnListenAsync<T>()
        {   
            if (_settings.IsAvailable(MessageBrokerLogType.ListenAsync) == false)
                return;

            _logger.Log($"{typeof(T)} is listened async.", _settings.LogParameters);
        }
        
        public void OnPublishAsync<T>()
        {
            if (_settings.IsAvailable(MessageBrokerLogType.PublishAsync) == false)
                return;

            _logger.Log($"{typeof(T)} is published async.", _settings.LogParameters);
        }
    }
}