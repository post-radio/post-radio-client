using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using Cysharp.Threading.Tasks;
using Ragon.Client;

namespace GamePlay.Player.Services.Factory.Runtime
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