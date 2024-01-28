using Common.Architecture.Scopes.Runtime;
using Common.Architecture.Scopes.Runtime.Services;
using VContainer.Unity;

namespace Common.Architecture.Scopes.Factory
{
    public interface IScopeLoaderFactory
    {
        IScopeLoader Create(IScopeConfig config, LifetimeScope parent);
    }
}