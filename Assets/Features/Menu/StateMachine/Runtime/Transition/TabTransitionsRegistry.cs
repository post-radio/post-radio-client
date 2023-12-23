using System.Collections.Generic;
using Menu.StateMachine.Definitions;
using UnityEngine;

namespace Menu.StateMachine.Runtime.Transition
{
    [DisallowMultipleComponent]
    public class TabTransitionsRegistry : MonoBehaviour, ITransitionPointsRegistry
    {
        [SerializeField] private TransitionPointsDictionary _points;

        private IReadOnlyDictionary<ITabDefinition, Transform> _castedPoints;

        public void Setup()
        {
            var dictionary = new Dictionary<ITabDefinition, Transform>();

            foreach (var (tab, rect) in _points)
                dictionary.Add(tab, rect);

            _castedPoints = dictionary;
        }

        public Vector2 GetTarget(ITabDefinition tabDefinition)
        {
            var target = _castedPoints[tabDefinition];

            return target.position;
        }
    }
}