using Cysharp.Threading.Tasks;

namespace Common.Architecture.Callbacks
{
    public interface ICallbacksHandler
    {
        public void Add(ICallbackEntity handler);

        public void Listen(object listener);

        public UniTask Run();
    }
}