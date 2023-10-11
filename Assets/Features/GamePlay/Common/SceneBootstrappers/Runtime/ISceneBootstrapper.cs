using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;

namespace GamePlay.Common.SceneBootstrappers.Runtime
{
    public interface ISceneBootstrapper
    {
        void Build(IServiceCollection builder, IScopeCallbacks callbacks);
    }
}