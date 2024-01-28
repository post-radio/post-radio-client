using Common.Architecture.Entities.Runtime.Callbacks;
using Internal.Services.Options.Runtime;
using VContainer.Unity;

namespace Common.Architecture.Entities.Runtime
{
    public interface IEntityUtils
    {
        IOptions Options { get; }
        IEntityCallbacks Callbacks { get; }
        LifetimeScope Scope { get; }
    }
}