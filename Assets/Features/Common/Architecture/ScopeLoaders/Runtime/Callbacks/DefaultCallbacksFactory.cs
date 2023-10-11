using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;

namespace Common.Architecture.ScopeLoaders.Runtime.Callbacks
{
    public class DefaultCallbacksFactory : ICallbacksFactory
    {
        /// <summary>
        /// 0 - ContainerBuilt
        /// 1 - Awake
        /// 2 - AwakeAsync
        /// 3 - Enabled
        /// 4 - EnabledAsync
        /// 5 - OnLoaded
        /// 6 - OnLoadedAsync
        /// 7 - OnDisabled
        /// </summary>
        /// <param name="callbacks"></param>
        /// <param name="data"></param>
        public void AddCallbacks(IScopeCallbacks callbacks, IScopeData data)
        {
            callbacks.AddCallback<IScopeBuiltListener>(
                listener => listener.OnContainerBuilt(data.Scope), CallbackStage.Construct, 0);
            callbacks.AddCallback<IScopeAwakeListener>(
                listener => listener.OnAwake(), CallbackStage.Construct, 1000);
            callbacks.AddAsyncCallback<IScopeAwakeAsyncListener>(
                listener => listener.OnAwakeAsync(), CallbackStage.Construct, 2000);
            callbacks.AddCallback<IScopeEnableListener>(
                listener => listener.OnEnabled(), CallbackStage.Construct, 3000);
            callbacks.AddAsyncCallback<IScopeEnableAsyncListener>(
                listener => listener.OnEnabledAsync(), CallbackStage.Construct, 4000);

            callbacks.AddCallback<IScopeLoadListener>(
                listener => listener.OnLoaded(), CallbackStage.SetupComplete, 0);
            callbacks.AddAsyncCallback<IScopeLoadAsyncListener>(
                listener => listener.OnLoadedAsync(), CallbackStage.SetupComplete, 1000);
            
            callbacks.AddCallback<IScopeDisableListener>(
                listener => listener.OnDisabled(), CallbackStage.Dispose, 0);
            
            callbacks.AddAsyncCallback<IScopeDisableAsyncListener>(
                listener => listener.OnDisabledAsync(), CallbackStage.Dispose, 1000);
        }
    }
}