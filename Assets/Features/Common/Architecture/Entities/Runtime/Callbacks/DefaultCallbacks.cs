using Cysharp.Threading.Tasks;

namespace Common.Architecture.Entities.Runtime.Callbacks
{
    public interface IEntityAwakeListener
    {
        void OnAwake();
    }

    public interface IEntityAwakeAsyncListener
    {
        UniTask OnAwakeAsync();
    }

    public interface IEntityEnableListener
    {
        void OnEnabled();
    }

    public interface IEntityEnableAsyncListener
    {
        UniTask OnEnabledAsync();
    }

    public interface IEntityDisableListener
    {
        void OnDisabled();
    }

    public interface IEntityDisableAsyncListener
    {
        UniTask OnDisabledAsync();
    }

    public interface IEntitySwitchListener : IEntityEnableListener, IEntityDisableListener
    {
    }
}