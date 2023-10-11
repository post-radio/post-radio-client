using Common.Architecture.ScopeLoaders.Runtime;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using VContainer.Unity;

namespace Common.Architecture.ScopeLoaders.Factory
{
    public interface IScopeLoaderFactory
    {
        IScopeLoader Create(IScopeConfig config, LifetimeScope parent);
    }
}