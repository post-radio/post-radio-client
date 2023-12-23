using System;
using Common.DataTypes.Collections.SerializableDictionaries;
using Global.UI.Nova.Components;
using Menu.StateMachine.Definitions;
using NovaSamples.UIControls;

namespace Menu.Common.Navigation
{
    [Serializable]
    public class NavigationDictionary : SerializableDictionary<UIButton, TabDefinition>
    {
        
    }
}