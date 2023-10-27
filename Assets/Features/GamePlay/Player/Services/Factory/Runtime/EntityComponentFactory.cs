using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.EntityCreators.Runtime;
using Cysharp.Threading.Tasks;
using Ragon.Client;

namespace GamePlay.Player.Factory.Runtime
{
    public class EntityComponentFactory : IComponentFactory
    {
        public EntityComponentFactory(RagonEntity entity)
        {
            _entity = entity;
        }

        private readonly RagonEntity _entity;

        public async UniTask Create(IServiceCollection services, IEntityUtils utils)
        {
            services.RegisterInstance(_entity);
        }
    }
}