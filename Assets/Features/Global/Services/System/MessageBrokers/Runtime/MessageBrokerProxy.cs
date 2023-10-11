using System;
using Global.System.MessageBrokers.Logs;
using UniRx;

namespace Global.System.MessageBrokers.Runtime
{
    public class MessageBrokerProxy : IMessageBroker, IAsyncMessageBroker
    {
        public MessageBrokerProxy(MessageBrokerLogger logger, MessageBroker messageBroker, AsyncMessageBroker asyncMessageBroker)
        {
            _logger = logger;
            _messageBroker = messageBroker;
            _asyncMessageBroker = asyncMessageBroker;

            Msg.Inject(this, this);
        }

        private readonly MessageBrokerLogger _logger;
        private readonly MessageBroker _messageBroker;
        private readonly AsyncMessageBroker _asyncMessageBroker;

        public void Publish<T>(T message)
        {
            _logger.OnPublish<T>();

            _messageBroker.Publish(message);
        }

        public IObservable<T> Receive<T>()
        {
            _logger.OnListen<T>();

            return _messageBroker.Receive<T>();
        }

        public IObservable<Unit> PublishAsync<T>(T message)
        {
            _logger.OnPublishAsync<T>();

            return _asyncMessageBroker.PublishAsync(message);
        }

        public IDisposable Subscribe<T>(Func<T, IObservable<Unit>> asyncMessageReceiver)
        {
            _logger.OnListenAsync<T>();

            return _asyncMessageBroker.Subscribe(asyncMessageReceiver);
        }
    }
}