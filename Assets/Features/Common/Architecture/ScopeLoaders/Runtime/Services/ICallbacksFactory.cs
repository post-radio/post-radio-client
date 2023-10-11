using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Common.Architecture.ScopeLoaders.Runtime.Utils;

namespace Common.Architecture.ScopeLoaders.Runtime.Services
{
    public interface ICallbacksFactory
    {
        void AddCallbacks(IScopeCallbacks callbacks, IScopeData data);
    }
}