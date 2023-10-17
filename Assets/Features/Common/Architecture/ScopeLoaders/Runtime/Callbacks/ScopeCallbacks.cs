using System;
using System.Collections.Generic;
using Common.Architecture.DiContainer.Abstract;
using Cysharp.Threading.Tasks;

namespace Common.Architecture.ScopeLoaders.Runtime.Callbacks
{
    public class ScopeCallbacks : IScopeCallbacks
    {
        private readonly Dictionary<CallbackStage, ICallbacksHandler> _callbacks = new();
        private readonly List<ICallbackRegister> _genericRegisters = new();

        public IReadOnlyDictionary<CallbackStage, ICallbacksHandler> Handlers => _callbacks;

        public void Listen(object listener)
        {
            foreach (var (_, handler) in _callbacks)
                handler.Listen(listener);

            foreach (var register in _genericRegisters)
                register.Listen(listener);
        }

        public void AddScopeCallback<T>(Action<T> invoker, CallbackStage stage, int order)
        {
            var entity = new CallbackEntity<T>(invoker, order);
            _callbacks.TryAdd(stage, new CallbacksHandler());
            _callbacks[stage].Add(entity);
        }

        public void AddScopeAsyncCallback<T>(Func<T, UniTask> invoker, CallbackStage stage, int order)
        {
            var entity = new AsyncCallbackEntity<T>(invoker, order);
            _callbacks.TryAdd(stage, new CallbacksHandler());
            _callbacks[stage].Add(entity);
        }

        public void AddGenericCallbackRegister(ICallbackRegister callbackRegister)
        {
            _genericRegisters.Add(callbackRegister);
        }
    }
}