using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;

namespace Common.Architecture.ScopeLoaders.Runtime.Callbacks
{
    public class CallbacksHandler : ICallbacksHandler
    {
        private readonly List<ICallbackEntity> _callbacks = new();

        public void Add(ICallbackEntity handler)
        {
            _callbacks.Add(handler);
        }

        public void Listen(object listener)
        {
            foreach (var callbackHandler in _callbacks)
                callbackHandler.Listen(listener);
        }
        
        public async UniTask Run()
        {
            var orderedCallbacks = _callbacks.OrderBy(t => t.Order);

            foreach (var handler in orderedCallbacks)
                await handler.InvokeAsync();
        }
    }
}