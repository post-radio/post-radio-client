using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Callbacks;

namespace GamePlay.Common.SceneBootstrappers.Runtime
{
    public interface ISceneBootstrapper
    {
        void Build(IServiceCollection builder, IScopeCallbacks callbacks);
    }
}