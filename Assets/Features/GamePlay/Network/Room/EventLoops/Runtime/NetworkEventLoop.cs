using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;

namespace GamePlay.Network.Room.EventLoops.Runtime
{
    public class NetworkEventLoop : ICallbacksFactory
    {
        public void AddCallbacks(IScopeCallbacks callbacks, IScopeData data)
        {
            callbacks.AddCallback<INetworkStartListener>(
                listener => listener.OnNetworkStart(), CallbackStage.Construct, 1);
            callbacks.AddCallback<INetworkAttachedListener>(
                listener => listener.OnNetworkAttached(), CallbackStage.Construct, 4001);
            callbacks.AddAsyncCallback<INetworkSetupListener>(
                listener => listener.OnNetworkSetupAsync(), CallbackStage.Construct, 4002);
        }
    }
}