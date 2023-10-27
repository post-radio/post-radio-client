using System.Collections.Generic;
using Common.Architecture.Callbacks;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Internal.Services.Scenes.Abstract;
using VContainer.Unity;

namespace Common.Architecture.ScopeLoaders.Runtime
{
    public interface IScopeLoadResult
    {
        IReadOnlyDictionary<CallbackStage, ICallbacksHandler> Callbacks { get; }
        IReadOnlyList<ISceneLoadResult> Scenes { get; }
        LifetimeScope Scope { get; }
    }
}