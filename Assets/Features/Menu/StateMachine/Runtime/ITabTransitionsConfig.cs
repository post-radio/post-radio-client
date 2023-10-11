using UnityEngine;

namespace Menu.StateMachine.Runtime
{
    public interface ITabTransitionsConfig
    {
        public float MaxHeight { get; }
        public AnimationCurve VerticalCurve { get; }
        public AnimationCurve HorizontalCurve { get; }
        
        public float MaxRotation { get; }
        public AnimationCurve RotationCurve { get; }
        
        public float Time { get; }
    }
}