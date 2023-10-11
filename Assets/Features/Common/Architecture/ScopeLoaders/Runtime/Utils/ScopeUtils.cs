using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Internal.Services.Options.Runtime;
using Internal.Services.Scenes.Abstract;

namespace Common.Architecture.ScopeLoaders.Runtime.Utils
{
    public class ScopeUtils : IScopeUtils
    {
        public ScopeUtils(
            IOptions options,
            ISceneLoader sceneLoader,
            IScopeBinder binder,
            IScopeData data,
            IScopeCallbacks callbacks)
        {
            _options = options;
            _sceneLoader = sceneLoader;
            _binder = binder;
            _data = data;
            _callbacks = callbacks;
        }
        
        private readonly IOptions _options;
        private readonly ISceneLoader _sceneLoader;
        private readonly IScopeBinder _binder;
        private readonly IScopeData _data;
        private readonly IScopeCallbacks _callbacks;

        public IOptions Options => _options;
        public ISceneLoader SceneLoader => _sceneLoader;
        public IScopeBinder Binder => _binder;
        public IScopeData Data => _data;
        public IScopeCallbacks Callbacks => _callbacks;
    }
}