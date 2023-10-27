using System.Collections.Generic;
using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.EntityCreators.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using Internal.Services.Options.Runtime;
using VContainer;
using VContainer.Unity;
using ContainerBuilder = Common.Architecture.DiContainer.Runtime.ContainerBuilder;

namespace Common.Architecture.EntityCreators.Runtime
{
    public class EntityCreator : IEntityCreator
    {
        public EntityCreator(IOptions options, IEntityConfig config, LifetimeScope parent)
        {
            _options = options;
            _config = config;
            _parent = parent;
        }

        private readonly IOptions _options;
        private readonly IEntityConfig _config;
        private readonly LifetimeScope _parent;

        public IEntityConfig Config => _config;

        public async UniTask<T> Create<T>(EntitySetupView view, IReadOnlyList<IComponentFactory> runtimeFactories)
        {
            var utils =  CreateUtils(view);
            var builder = new ContainerBuilder();
            
            await CreateServices(builder, utils, view, runtimeFactories);
            await BuildContainer(builder, utils);
            
            return view.Scope.Container.Resolve<T>();
        }

        private IEntityUtils CreateUtils(EntitySetupView view)
        {
            var callbacks = new EntityCallbacks();

            var utils = new EntityUtils(_options, callbacks, view.Scope);

            return utils;
        }

        private async UniTask CreateServices(
            IServiceCollection services, 
            IEntityUtils utils,
            EntitySetupView view,
            IReadOnlyList<IComponentFactory> runtimeFactories)
        {
            foreach (var factory in _config.Callbacks)
                factory.AddCallbacks(utils.Callbacks);

            var tasks = new List<UniTask>();

            foreach (var factory in _config.Components)
                tasks.Add(factory.Create(services, utils));

            foreach (var factory in runtimeFactories)
                tasks.Add(factory.Create(services, utils));
            
            view.CreateViews(services, utils);
            
            await UniTask.WhenAll(tasks);
        }

        private async UniTask BuildContainer(IDependenciesBuilder builder, IEntityUtils utils)
        {
            using (LifetimeScope.EnqueueParent(_parent))
            {
                using (LifetimeScope.Enqueue(Register))
                {
                    await UniTask.RunOnThreadPool(async () => utils.Scope.Build());
                }
            }

            builder.ResolveAllWithCallbacks(utils.Scope.Container, utils.Callbacks);

            void Register(IContainerBuilder container)
            {
                builder.RegisterAll(container);
            }
        }
    }
}