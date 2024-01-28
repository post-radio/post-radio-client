using Common.Architecture.Entities.Runtime;
using VContainer.Unity;

namespace Common.Architecture.Entities.Factory
{
    public interface IEntityCreatorFactory
    {
        IEntityCreator Create(IEntityConfig config, LifetimeScope parent);
    }
}