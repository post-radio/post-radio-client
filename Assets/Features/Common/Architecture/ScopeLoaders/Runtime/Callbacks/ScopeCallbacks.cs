using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace Common.Architecture.ScopeLoaders.Runtime.Callbacks
{
    public class ScopeCallbacks : IScopeCallbacks
    {
        private readonly Dictionary<CallbackStage, ICallbacksHandler> _callbacks = new();

        public IReadOnlyDictionary<CallbackStage, ICallbacksHandler> Handlers => _callbacks;
        
        public void Listen(object listener)
        {
            foreach (var (_, handler) in _callbacks)
            {
                handler.Listen(listener);
            }
        }

        public void AddCallback<T>(Action<T> invoker, CallbackStage stage, int order)
        {
            var entity = new CallbackEntity<T>(invoker, order);
            _callbacks.TryAdd(stage, new CallbacksHandler());
            _callbacks[stage].Add(entity);
        }

        public void AddAsyncCallback<T>(Func<T, UniTask> invoker, CallbackStage stage, int order)
        {
            var entity = new AsyncCallbackEntity<T>(invoker, order);
            _callbacks.TryAdd(stage, new CallbacksHandler());
            _callbacks[stage].Add(entity);
        }
    }
}