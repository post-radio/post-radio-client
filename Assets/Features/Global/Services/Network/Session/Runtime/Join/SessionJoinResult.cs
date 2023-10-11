namespace Global.Network.Session.Runtime.Join
{
    public readonly struct SessionJoinResult
    {
        public SessionJoinResult(SessionJoinResultType type)
        {
            Type = type;
            ErrorMessage = string.Empty;
        }
        
        public SessionJoinResult(SessionJoinResultType type, string errorMessage)
        {
            Type = type;
            ErrorMessage = errorMessage;
        }
        
        public readonly SessionJoinResultType Type;
        public readonly string ErrorMessage;
    }
}