using System;
using Common.Serialization.SerializableDictionaries;
using Menu.StateMachine.Definitions;
using UnityEngine;

namespace Menu.StateMachine.Runtime.Transition
{
    [Serializable]
    public class TransitionPointsDictionary : SerializableDictionary<TabDefinition, RectTransform>
    {
    }
}