using System.Collections.Generic;
using Common.Architecture.Callbacks;
using Common.Architecture.Scopes.Runtime.Callbacks;
using Common.Architecture.Scopes.Runtime.Utils;
using Internal.Services.Scenes.Abstract;
using VContainer.Unity;

namespace Common.Architecture.Scopes.Runtime
{
    public class ScopeLoadResult : IScopeLoadResult
    {
        public ScopeLoadResult(LifetimeScope scope, IScopeCallbacks callbacks, ScopeSceneLoader sceneLoader)
        {
            _callbacks = callbacks.Handlers;
            _scenes = sceneLoader.Results;
            _scope = scope;
        }

        public ScopeLoadResult(LifetimeScope scope, IReadOnlyDictionary<CallbackStage, ICallbacksHandler> callbacks,
            IReadOnlyList<ISceneLoadResult> scenes)
        {
            _callbacks = callbacks;
            _scenes = scenes;
            _scope = scope;
        }

        private readonly IReadOnlyDictionary<CallbackStage, ICallbacksHandler> _callbacks;
        private readonly IReadOnlyList<ISceneLoadResult> _scenes;
        private readonly LifetimeScope _scope;

        public IReadOnlyDictionary<CallbackStage, ICallbacksHandler> Callbacks => _callbacks;
        public IReadOnlyList<ISceneLoadResult> Scenes => _scenes;
        public LifetimeScope Scope => _scope;
    }
}