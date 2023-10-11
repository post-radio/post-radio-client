using Cysharp.Threading.Tasks;
using Menu.StateMachine.Definitions;
using UnityEngine;

namespace Menu.StateMachine.Runtime
{
    public interface ITabTransitionHandler
    {
        public UniTask Transit(ITab tab, Vector2 from, Vector2 to);
    }
}