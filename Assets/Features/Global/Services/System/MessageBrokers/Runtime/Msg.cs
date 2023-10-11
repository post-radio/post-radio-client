using System;
using Cysharp.Threading.Tasks;
using UniRx;

namespace Global.System.MessageBrokers.Runtime
{
    public static class Msg
    {
        private static IMessageBroker _messageBroker;
        private static IAsyncMessageBroker _asyncMessageBroker;
        
        internal static void Inject(IMessageBroker messageBroker, IAsyncMessageBroker asyncMessageBroker)
        {
            _messageBroker = messageBroker;
            _asyncMessageBroker = asyncMessageBroker;
        }

        public static void Publish<T>(T message)
        {
            _messageBroker.Publish(message);
        }

        public static IDisposable Listen<T>(Action<T> listener)
        {
            return _messageBroker.Receive<T>().Subscribe(listener);
        }
        
        public static async UniTask<IObservable<Unit>> PublishAsync<T>(T message)
        {
            return _asyncMessageBroker.PublishAsync(message);
        }
        
        public static IDisposable ListenAsync<T>(Func<T, IObservable<Unit>> listener)
        {
            return _asyncMessageBroker.Subscribe(listener);
        }
    }
}