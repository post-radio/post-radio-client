using System.Threading;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using Menu.StateMachine.Definitions;
using Menu.StateMachine.Registry;

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
            var all = _tabsRegistry.GetAll();
            var randomPoint = _transitionPointsRegistry.GetPoints(TabTransitionType.LeftToRight);

            foreach (var tab in all)
            {
                tab.Transform.anchoredPosition = randomPoint.To;
            }
        }

        public async UniTask Select(ITabDefinition tabDefinition, TabTransitionType transitionType)
        {
            var target = _tabsRegistry.GetTab(tabDefinition);
            var transitionPoints = _transitionPointsRegistry.GetPoints(transitionType);

            if (_current != null)
            {
                _current.Deactivate();
                _transitionHandler.Transit(_current, transitionPoints.Center, transitionPoints.To).Forget();
            }

            await _transitionHandler.Transit(target, transitionPoints.From, transitionPoints.Center);
            _current = target;
            var cancellation = new CancellationTokenSource(); 
            target.Activate(cancellation.Token);
        }
    }
}