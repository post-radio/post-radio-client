using System;
using Menu.StateMachine.Definitions;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Menu.StateMachine.Runtime
{
    [DisallowMultipleComponent]
    public class TabTransitionsRegistry : MonoBehaviour, ITransitionPointsRegistry
    {
        [SerializeField] private RectTransform[] _left;
        [SerializeField] private RectTransform[] _right;
        [SerializeField] private RectTransform[] _top;
        [SerializeField] private RectTransform[] _bottom;

        [SerializeField] private RectTransform _center;
        
        public TransitionPoints GetPoints(TabTransitionType type)
        {
            var center = _center.anchoredPosition;
            
            switch (type)
            {
                case TabTransitionType.RightToLeft:
                {
                    var from = GetRandom(_right);
                    var to = GetRandom(_left);

                    return new TransitionPoints(from, to, center);
                }
                case TabTransitionType.LeftToRight:
                {
                    var from = GetRandom(_left);
                    var to = GetRandom(_right);

                    return new TransitionPoints(from, to, center);
                }
                case TabTransitionType.TopToBottom:
                {
                    var from = GetRandom(_top);
                    var to = GetRandom(_bottom);

                    return new TransitionPoints(from, to, center);
                }
                case TabTransitionType.BottomToTop:
                {
                    var from = GetRandom(_bottom);
                    var to = GetRandom(_top);

                    return new TransitionPoints(from, to, center);
                }
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }    
        }

        private Vector2 GetRandom(RectTransform[] points)
        {
            var random = Random.Range(0, points.Length);
            return points[random].anchoredPosition;
        }
    }
}