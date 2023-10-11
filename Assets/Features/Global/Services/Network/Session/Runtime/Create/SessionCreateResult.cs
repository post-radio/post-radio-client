    namespace Global.Network.Session.Runtime.Create
    {
        public class SessionCreateResult
        {
            public SessionCreateResult(SessionCreateResultType type)
            {
                Type = type;
                ErrorMessage = string.Empty;
            }
        
            public SessionCreateResult(SessionCreateResultType type, string errorMessage)
            {
                Type = type;
                ErrorMessage = errorMessage;
            }
        
            public readonly SessionCreateResultType Type;
            public readonly string ErrorMessage;
        }
    }
