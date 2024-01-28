using Common.Architecture.Entities.Runtime;
using Internal.Services.Options.Runtime;
using VContainer.Unity;

namespace Common.Architecture.Entities.Factory
{
    public class EntityCreatorFactory : IEntityCreatorFactory
    {
        public EntityCreatorFactory(IOptions options)
        {
            _options = options;
        }
        
        private readonly IOptions _options;

        public IEntityCreator Create(IEntityConfig config, LifetimeScope parent)
        {
            return new EntityCreator(_options, config, parent);
        }
    }
}