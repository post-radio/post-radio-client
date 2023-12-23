using GamePlay.Player.Services.Lists.Runtime;
using Ragon.Client;

namespace GamePlay.Network.Messaging.Events.Runtime
{
    public class NetworkEventsDistributor : INetworkEventsDistributor
    {
        public NetworkEventsDistributor(INetworkEvents events, IPlayersList players)
        {
            _events = events;
            _players = players;
        }

        private readonly INetworkEvents _events;
        private readonly IPlayersList _players;
        
        public void SendAll<TEvent>(TEvent payload) where TEvent : IRagonEvent, new()
        {
            _events.SendEvent(payload);
        }

        public void SendOwner<TEvent>(TEvent payload) where TEvent : IRagonEvent, new()
        {
            _events.SendEvent(payload, _players.Owner.Player);
        }
    }
}