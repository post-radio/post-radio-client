using Menu.StateMachine.Definitions;

namespace Menu.StateMachine.Runtime
{
    public interface ITransitionPointsRegistry
    {
        TransitionPoints GetPoints(TabTransitionType type);
    }
}