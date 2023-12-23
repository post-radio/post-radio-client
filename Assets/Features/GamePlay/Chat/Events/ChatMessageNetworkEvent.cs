using Ragon.Client;
using Ragon.Protocol;

namespace GamePlay.Chat.Events
{
    public class ChatMessageNetworkEvent : IRagonEvent
    {
        public string Message;
        
        public void Serialize(RagonBuffer buffer)
        {
            buffer.WriteString(Message);
        }

        public void Deserialize(RagonBuffer buffer)
        {
            Message = buffer.ReadString();
        }
    }
}