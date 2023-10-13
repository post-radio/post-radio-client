using Ragon.Client;

namespace GamePlay.Network.Room.EventLoops.Runtime
{
    public interface INetworkEventsRegistrationListener
    {
        void RegisterEvents(RagonEventCache events);
    }
}