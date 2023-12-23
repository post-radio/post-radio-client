namespace GamePlay.Chat.Events
{
    public class ChatMessageSubmittedEvent
    {
        public ChatMessageSubmittedEvent(string message)
        {
            Message = message;
        }
        
        public readonly string Message;
    }
}