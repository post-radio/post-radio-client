using System;
using Menu.StateMachine.Definitions;
using UnityEngine;

namespace Menu.Common.Navigation
{
    [Serializable]
    public class NavigationEntry
    {
        [SerializeField] private TabDefinition _definition;
        [SerializeField] private TabTransitionType _type;

        public TabDefinition Definition => _definition;
        public TabTransitionType Type => _type;
    }
}