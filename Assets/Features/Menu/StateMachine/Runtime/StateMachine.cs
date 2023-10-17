using System.Threading;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using Menu.StateMachine.Definitions;
using Menu.StateMachine.Registry;
using Menu.StateMachine.Runtime.Transition;

namespace Menu.StateMachine.Runtime
{
    public class StateMachine : IStateMachine, IScopeAwakeListener
    {
        public StateMachine(ITabsRegistry tabsRegistry, ITransitionPointsRegistry transitionPointsRegistry,
            ITabTransitionHandler transitionHandler)
        {
            _tabsRegistry = tabsRegistry;
            _transitionPointsRegistry = transitionPointsRegistry;
            _transitionHandler = transitionHandler;
        }

        private readonly ITabsRegistry _tabsRegistry;
        private readonly ITransitionPointsRegistry _transitionPointsRegistry;
        private readonly ITabTransitionHandler _transitionHandler;

        private ITab _current;

        public void OnAwake()
        {
            _transitionPointsRegistry.Setup();
            ;
        }

        public async UniTask Select(ITabDefinition tabDefinition)
        {
            var target = _tabsRegistry.GetTab(tabDefinition);
            var targetPoint = _transitionPointsRegistry.GetTarget(tabDefinition);

            if (_current != null)
            {
                _current.Deactivate();
                _transitionHandler.Transit(targetPoint).Forget();
            }

            await _transitionHandler.Transit(targetPoint);
            _current = target;
            var cancellation = new CancellationTokenSource();
            target.Activate(cancellation.Token);
        }
    }
}