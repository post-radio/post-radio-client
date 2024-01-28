using Cysharp.Threading.Tasks;
using VContainer.Unity;

namespace Common.Architecture.Scopes.Runtime.Callbacks
{
    public interface IScopeAwakeListener
    {
        void OnAwake();
    }

    public interface IScopeAwakeAsyncListener
    {
        UniTask OnAwakeAsync();
    }

    public interface IScopeEnableListener
    {
        void OnEnabled();
    }

    public interface IScopeEnableAsyncListener
    {
        UniTask OnEnabledAsync();
    }

    public interface IScopeDisableListener
    {
        void OnDisabled();
    }

    public interface IScopeDisableAsyncListener
    {
        UniTask OnDisabledAsync();
    }

    public interface IScopeLoadListener
    {
        void OnLoaded();
    }

    public interface IScopeLoadAsyncListener
    {
        UniTask OnLoadedAsync();
    }

    public interface IScopeBuiltListener
    {
        void OnContainerBuilt(LifetimeScope scope);
    }

    public interface IScopeSwitchListener : IScopeEnableListener, IScopeDisableListener
    {
    }
}