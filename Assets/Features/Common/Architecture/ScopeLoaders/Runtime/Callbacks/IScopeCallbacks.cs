using System;
using System.Collections.Generic;
using Common.Architecture.DiContainer.Abstract;
using Cysharp.Threading.Tasks;

namespace Common.Architecture.ScopeLoaders.Runtime.Callbacks
{
    public interface IScopeCallbacks : ICallbackRegister
    {
        public IReadOnlyDictionary<CallbackStage, ICallbacksHandler> Handlers { get; }
        
        void AddCallback<T>(Action<T> invoker, CallbackStage stage, int order);
        void AddAsyncCallback<T>(Func<T, UniTask> invoker, CallbackStage stage, int order);
    }
}