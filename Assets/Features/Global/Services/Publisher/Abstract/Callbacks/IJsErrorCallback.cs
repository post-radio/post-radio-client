using System;

namespace Features.Global.Services.Publisher.Abstract.Callbacks
{
    public interface IJsErrorCallback
    {
        event Action<string> Exception; 
    }
}