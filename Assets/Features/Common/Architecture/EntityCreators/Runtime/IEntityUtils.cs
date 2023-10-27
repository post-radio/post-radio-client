using Common.Architecture.EntityCreators.Runtime.Callbacks;
using Internal.Services.Options.Runtime;
using VContainer.Unity;

namespace Common.Architecture.EntityCreators.Runtime
{
    public interface IEntityUtils
    {
        IOptions Options { get; }
        IEntityCallbacks Callbacks { get; }
        LifetimeScope Scope { get; }
    }
}