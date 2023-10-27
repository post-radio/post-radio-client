using System.Collections.Generic;
using Ragon.Client;
using Ragon.Protocol;

namespace Common.Network
{
    public abstract class NetworkEvent : IRagonEvent
    {
        private IReadOnlyList<IRagonEvent> _events;

        public void Construct(params IRagonEvent[] events)
        {
            _events = events;
        }

        public void Serialize(RagonBuffer buffer)
        {
            foreach (var ragonEvent in _events)
                ragonEvent.Serialize(buffer);

            OnSerialize(buffer);    
        }

        public void Deserialize(RagonBuffer buffer)
        {
            foreach (var ragonEvent in _events)
                ragonEvent.Deserialize(buffer);
            
            OnDeserialize(buffer);    
        }

        protected virtual void OnSerialize(RagonBuffer buffer) {}
        protected virtual void OnDeserialize(RagonBuffer buffer) {}
    }
}