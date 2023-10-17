using Cysharp.Threading.Tasks;
using Menu.StateMachine.Definitions;

namespace Menu.StateMachine.Runtime
{
    public interface IStateMachine
    {
        UniTask Select(ITabDefinition tabDefinition);
    }
}