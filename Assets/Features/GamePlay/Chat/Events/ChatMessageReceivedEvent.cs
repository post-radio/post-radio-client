using GamePlay.Player.Entity.Definition;

namespace GamePlay.Chat.Events
{
    public class ChatMessageReceivedEvent
    {
        public ChatMessageReceivedEvent(INetworkPlayer player, string message)
        {
            Player = player;
            Message = message;
        }
        
        public readonly INetworkPlayer Player;
        public readonly string Message;
    }
}