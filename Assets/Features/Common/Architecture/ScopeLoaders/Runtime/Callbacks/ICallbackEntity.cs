using Cysharp.Threading.Tasks;

namespace Common.Architecture.ScopeLoaders.Runtime.Callbacks
{
    public interface ICallbackEntity
    {
        int Order { get; }

        void Listen(object target);
        UniTask InvokeAsync();
    }
}