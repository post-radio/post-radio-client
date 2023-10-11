using UnityEngine;

namespace Menu.StateMachine.Runtime
{
    public readonly struct TransitionPoints
    {
        public TransitionPoints(Vector2 from, Vector2 to, Vector2 center)
        {
            From = from;
            To = to;
            Center = center;
        }
        
        public readonly Vector2 From;
        public readonly Vector2 To;
        public readonly Vector2 Center;
    }
}