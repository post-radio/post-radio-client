using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using Menu.StateMachine.Definitions;
using Menu.StateMachine.Runtime;

namespace Menu.Loop.Runtime
{
    public class MenuLoop : IScopeLoadListener
    {
        public MenuLoop(IStateMachine stateMachine, ITabDefinition mainDefinition)
        {
            _stateMachine = stateMachine;
            _mainDefinition = mainDefinition;
        }
        
        private readonly IStateMachine _stateMachine;
        private readonly ITabDefinition _mainDefinition;

        public void OnLoaded()
        {
             _stateMachine.Select(_mainDefinition).Forget();
        }
    }
}