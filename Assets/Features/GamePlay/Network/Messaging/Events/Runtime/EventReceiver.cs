using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Ragon.Client;

namespace GamePlay.Network.Messaging.Events.Runtime
{
    public class EventReceiver<TEvent>
    {
        public EventReceiver(
            CancellationToken cancellation, 
            Func<RagonPlayer, TEvent, CancellationToken, UniTask> listener)
        {
            _cancellation = cancellation;
            _listener = listener;
        }
        
        private readonly CancellationToken _cancellation;
        private readonly Func<RagonPlayer, TEvent, CancellationToken, UniTask> _listener;

        public void Listener(RagonPlayer player, TEvent payload)
        {
            _listener?.Invoke(player, payload, _cancellation).Forget();
        }
    }
}