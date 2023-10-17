using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Menu.StateMachine.Runtime.Transition
{
    public interface ITabTransitionHandler
    {
        public UniTask Transit(Vector2 to);
    }
}