using Common.Architecture.Scopes.Runtime;
using Common.Architecture.Scopes.Runtime.Services;
using Internal.Services.Loggers.Runtime;
using Internal.Services.Options.Runtime;
using Internal.Services.Scenes.Abstract;
using VContainer.Unity;

namespace Common.Architecture.Scopes.Factory
{
    public class ScopeLoaderFactory : IScopeLoaderFactory
    {
        public ScopeLoaderFactory(ILogger logger, ISceneLoader sceneLoader, IOptions options)
        {
            _logger = logger;
            _sceneLoader = sceneLoader;
            _options = options;
        }
        
        private readonly ILogger _logger;
        private readonly ISceneLoader _sceneLoader;
        private readonly IOptions _options;
        
        public IScopeLoader Create(IScopeConfig config, LifetimeScope parent)
        {
            return new ScopeLoader(_logger, _sceneLoader, _options, parent, config);
        }
    }
}