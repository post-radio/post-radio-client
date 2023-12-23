using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Ragon.Client;

namespace GamePlay.Network.Messaging.Events.Runtime
{
    public interface INetworkEvents
    {
        void AddRoute<TEvent>(Action<RagonPlayer, TEvent> listener) where TEvent : IRagonEvent, new();
        void AddRouteAsync<TEvent>(Func<RagonPlayer, TEvent, CancellationToken, UniTask> listener)
            where TEvent : IRagonEvent, new();
        void SendEvent<TEvent>(TEvent payload) where TEvent : IRagonEvent, new();
        void SendEvent<TEvent>(TEvent payload, RagonPlayer player) where TEvent : IRagonEvent, new();
    }
}