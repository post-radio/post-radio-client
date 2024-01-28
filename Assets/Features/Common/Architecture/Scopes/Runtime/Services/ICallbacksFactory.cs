using Common.Architecture.Scopes.Runtime.Callbacks;
using Common.Architecture.Scopes.Runtime.Utils;

namespace Common.Architecture.Scopes.Runtime.Services
{
    public interface ICallbacksFactory
    {
        void AddCallbacks(IScopeCallbacks callbacks, IScopeData data);
    }
}