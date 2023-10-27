using Cysharp.Threading.Tasks;

namespace Common.Architecture.Callbacks
{
    public interface ICallbackEntity
    {
        int Order { get; }

        void Listen(object target);
        UniTask InvokeAsync();
    }
}