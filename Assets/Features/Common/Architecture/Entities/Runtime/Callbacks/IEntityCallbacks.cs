using System;
using System.Collections.Generic;
using Common.Architecture.Callbacks;
using Common.Architecture.Container.Abstract;
using Cysharp.Threading.Tasks;

namespace Common.Architecture.Entities.Runtime.Callbacks
{
    public interface IEntityCallbacks : ICallbackRegister
    {
        public IReadOnlyDictionary<CallbackStage, ICallbacksHandler> Handlers { get; }

        void AddScopeCallback<T>(Action<T> invoker, CallbackStage stage, int order);
        void AddScopeAsyncCallback<T>(Func<T, UniTask> invoker, CallbackStage stage, int order);

        void AddGenericCallbackRegister(ICallbackRegister callbackRegister);
    }
}