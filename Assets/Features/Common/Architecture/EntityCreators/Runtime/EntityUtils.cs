using Common.Architecture.EntityCreators.Runtime.Callbacks;
using Internal.Services.Options.Runtime;
using VContainer.Unity;

namespace Common.Architecture.EntityCreators.Runtime
{
    public class EntityUtils : IEntityUtils
    {
        public EntityUtils(IOptions options, IEntityCallbacks callbacks, LifetimeScope scope)
        {
            Options = options;
            Callbacks = callbacks;
            Scope = scope;
        }

        public IOptions Options { get; }
        public IEntityCallbacks Callbacks { get; }
        public LifetimeScope Scope { get; }
    }
}