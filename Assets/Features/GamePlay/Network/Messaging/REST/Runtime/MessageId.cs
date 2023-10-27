using System;
using GamePlay.Network.Messaging.REST.Runtime.Abstract;
using Ragon.Client;
using Ragon.Protocol;

namespace GamePlay.Network.Messaging.REST.Runtime
{
    public class MessageId : IRagonEvent, IMessageId
    {
        private const int _size = 100000000;
        private Guid _value;

        public Guid Value => _value;
        
        public void SetValue(Guid value)
        {
            _value = value;
        }

        public void Serialize(RagonBuffer buffer)
        {
            var bytes = _value.ToByteArray();

            buffer.WriteInt(bytes.Length, 0, _size);
            
            foreach (var value in bytes)
                buffer.WriteByte(value);
        }

        public void Deserialize(RagonBuffer buffer)
        {
            var length = buffer.ReadInt(0, _size);
            var bytes = new byte[length];
            for (var i = 0; i < length; i++)
                bytes[i] = buffer.ReadByte();
            
            _value = new Guid(bytes);
        }
    }
}