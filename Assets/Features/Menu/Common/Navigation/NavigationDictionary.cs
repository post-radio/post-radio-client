using System;
using Common.Serialization.SerializableDictionaries;
using Common.UI.Buttons;
using Menu.StateMachine.Definitions;

namespace Menu.Common.Navigation
{
    [Serializable]
    public class NavigationDictionary : SerializableDictionary<ExtendedButton, TabDefinition>
    {
        
    }
}