using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;

namespace Common.Architecture.Scopes.Runtime.Callbacks
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
            callbacks.AddScopeCallback<IScopeBuiltListener>(
                listener => listener.OnContainerBuilt(data.Scope), CallbackStage.Construct, 0);
            callbacks.AddScopeCallback<IScopeAwakeListener>(
                listener => listener.OnAwake(), CallbackStage.Construct, 1000);
            callbacks.AddScopeAsyncCallback<IScopeAwakeAsyncListener>(
                listener => listener.OnAwakeAsync(), CallbackStage.Construct, 2000);
            callbacks.AddScopeCallback<IScopeEnableListener>(
                listener => listener.OnEnabled(), CallbackStage.Construct, 3000);
            callbacks.AddScopeAsyncCallback<IScopeEnableAsyncListener>(
                listener => listener.OnEnabledAsync(), CallbackStage.Construct, 4000);

            callbacks.AddScopeCallback<IScopeLoadListener>(
                listener => listener.OnLoaded(), CallbackStage.SetupComplete, 0);
            callbacks.AddScopeAsyncCallback<IScopeLoadAsyncListener>(
                listener => listener.OnLoadedAsync(), CallbackStage.SetupComplete, 1000);

            callbacks.AddScopeCallback<IScopeDisableListener>(
                listener => listener.OnDisabled(), CallbackStage.Dispose, 0);

            callbacks.AddScopeAsyncCallback<IScopeDisableAsyncListener>(
                listener => listener.OnDisabledAsync(), CallbackStage.Dispose, 1000);
        }
    }
}