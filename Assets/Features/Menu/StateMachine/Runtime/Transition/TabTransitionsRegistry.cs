using System.Collections.Generic;
using Menu.StateMachine.Definitions;
using UnityEngine;

namespace Menu.StateMachine.Runtime.Transition
{
    [DisallowMultipleComponent]
    public class TabTransitionsRegistry : MonoBehaviour, ITransitionPointsRegistry
    {
        [SerializeField] private TransitionPointsDictionary _points;

        private IReadOnlyDictionary<ITabDefinition, RectTransform> _castedPoints;

        public void Setup()
        {
            var dictionary = new Dictionary<ITabDefinition, RectTransform>();

            foreach (var (tab, rect) in _points)
                dictionary.Add(tab, rect);

            _castedPoints = dictionary;
        }

        public Vector2 GetTarget(ITabDefinition tabDefinition)
        {
            var rect = _castedPoints[tabDefinition];

            return rect.position;
        }
    }
}