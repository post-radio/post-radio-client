using Menu.StateMachine.Common;
using NaughtyAttributes;
using UnityEngine;

namespace Menu.StateMachine.Runtime.Transition
{
    [CreateAssetMenu(fileName = StateMachineRoutes.ConfigName,
        menuName = StateMachineRoutes.ConfigPath)]
    public class TabsTabTransitionConfig : ScriptableObject, ITabTransitionsConfig
    {
        [SerializeField] private float _maxHeight;
        [SerializeField] [CurveRange(0f, -1f, 1f, 1f)] private AnimationCurve _verticalCurve;
        [SerializeField] [CurveRange(0f, 0f, 1f, 1f)] private AnimationCurve _horizontalCurve;

        [SerializeField] private float _maxRotation;
        [SerializeField] [CurveRange(0f, -1f, 1f, 1f)] private AnimationCurve _rotationCurve;

        [SerializeField] private float _time;

        public float MaxHeight => _maxHeight;
        public AnimationCurve VerticalCurve => _verticalCurve;
        public AnimationCurve HorizontalCurve => _horizontalCurve;
        public float MaxRotation => _maxRotation;
        public AnimationCurve RotationCurve => _rotationCurve;
        public float Time => _time;
    }
}