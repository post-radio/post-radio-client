using VContainer.Unity;

namespace Common.Architecture.ScopeLoaders.Runtime.Utils
{
    public interface IScopeData
    {
        LifetimeScope Scope { get; }
    }
}