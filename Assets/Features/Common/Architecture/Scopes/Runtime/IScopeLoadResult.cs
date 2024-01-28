using System.Collections.Generic;
using Common.Architecture.Callbacks;
using Common.Architecture.Scopes.Runtime.Callbacks;
using Internal.Services.Scenes.Abstract;
using VContainer.Unity;

namespace Common.Architecture.Scopes.Runtime
{
    public interface IScopeLoadResult
    {
        IReadOnlyDictionary<CallbackStage, ICallbacksHandler> Callbacks { get; }
        IReadOnlyList<ISceneLoadResult> Scenes { get; }
        LifetimeScope Scope { get; }
    }
}