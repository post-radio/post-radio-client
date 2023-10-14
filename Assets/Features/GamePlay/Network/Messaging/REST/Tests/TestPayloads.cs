using System;
using GamePlay.Network.Messaging.REST.Runtime.Abstract;
using Ragon.Client;
using Ragon.Protocol;

namespace GamePlay.Network.Messaging.REST.Tests
{
    public class TestRequest : IRagonEvent, IMessage
    {
        public TestRequest()
        {
            
        }
        
        public int Value;
        private const int _intSize = 100000000;
        public Guid RequestId { get; set; }
        
        public void Serialize(RagonBuffer buffer)
        {
            var bytes = RequestId.ToByteArray();

            buffer.WriteInt(Value, 0, _intSize);
            buffer.WriteInt(bytes.Length, 0, _intSize);
            
            foreach (var value in bytes)
                buffer.WriteByte(value);
        }

        public void Deserialize(RagonBuffer buffer)
        {
            Value = buffer.ReadInt(0, _intSize);
            var length = buffer.ReadInt(0, _intSize);
            var bytes = new byte[length];
            for (var i = 0; i < length; i++)
                bytes[i] = buffer.ReadByte();
            RequestId = new Guid(bytes);
        }
    }
    
    public class TestResponse : IRagonEvent, IMessage
    {
        public TestResponse()
        {
            
        }
        
        private const int _intSize = 100000000;
        
        public int Value;
        public Guid RequestId { get; set; }
        
        public void Serialize(RagonBuffer buffer)
        {
            buffer.WriteInt(Value, 0, _intSize);
            var bytes = RequestId.ToByteArray();
            buffer.WriteInt(bytes.Length, 0, _intSize);
            
            foreach (var value in bytes)
                buffer.WriteByte(value);
        }

        public void Deserialize(RagonBuffer buffer)
        {
            Value = buffer.ReadInt(0, _intSize);
            var length = buffer.ReadInt(0, _intSize);
            var bytes = new byte[length];
            for (var i = 0; i < length; i++)
                bytes[i] = buffer.ReadByte();
            RequestId = new Guid(bytes);
        }
    }
}