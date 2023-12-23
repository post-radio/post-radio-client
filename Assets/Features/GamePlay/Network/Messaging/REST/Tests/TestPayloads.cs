using GamePlay.Network.Messaging.REST.Runtime;
using GamePlay.Network.Messaging.REST.Runtime.Abstract;
using Ragon.Client;
using Ragon.Protocol;

namespace GamePlay.Network.Messaging.REST.Tests
{
    public class TestRequest : IRagonEvent, IMessage
    {
        private const int _intSize = 100000000;
        
        private readonly MessageId _id = new(); 

        public int Value;
        
        public IMessageId RequestId => _id; 
        
        public void Serialize(RagonBuffer buffer)
        {
            _id.Serialize(buffer);

            buffer.WriteInt(Value, 0, _intSize);
        }

        public void Deserialize(RagonBuffer buffer)
        {
            _id.Deserialize(buffer);

            Value = buffer.ReadInt(0, _intSize);
        }
    }
    
    public class TestResponse : IRagonEvent, IMessage
    {
        private const int _intSize = 100000000;
        
        private readonly MessageId _id = new(); 

        public int Value;
        
        public IMessageId RequestId => _id; 
        
        public void Serialize(RagonBuffer buffer)
        {
            _id.Serialize(buffer);

            buffer.WriteInt(Value, 0, _intSize);
        }

        public void Deserialize(RagonBuffer buffer)
        {
            _id.Deserialize(buffer);

            Value = buffer.ReadInt(0, _intSize);
        }
    }
}