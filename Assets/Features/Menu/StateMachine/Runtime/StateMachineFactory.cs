using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Menu.StateMachine.Common;
using Menu.StateMachine.Registry;
using Menu.StateMachine.Runtime.Transition;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.StateMachine.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = StateMachineRoutes.ServiceName,
        menuName = StateMachineRoutes.ServicePath)]
    public class StateMachineFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private TabsTabTransitionConfig _config;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<StateMachine>()
                .As<IStateMachine>()
                .AsCallbackListener();

            services.Register<TabsRegistry>()
                .As<ITabsRegistry>();

            services.Register<TabTransitionHandler>()
                .WithParameter<ITabTransitionsConfig>(_config)
                .As<ITabTransitionHandler>();
        }
    }
}