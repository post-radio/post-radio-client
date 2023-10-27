using Common.Architecture.EntityCreators.Runtime;
using VContainer.Unity;

namespace Common.Architecture.EntityCreators.Factory
{
    public interface IEntityCreatorFactory
    {
        IEntityCreator Create(IEntityConfig config, LifetimeScope parent);
    }
}