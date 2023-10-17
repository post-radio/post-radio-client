using Menu.StateMachine.Definitions;
using UnityEngine;

namespace Menu.StateMachine.Runtime.Transition
{
    public interface ITransitionPointsRegistry
    {
        void Setup();
        Vector2 GetTarget(ITabDefinition tabDefinition);
    }
}