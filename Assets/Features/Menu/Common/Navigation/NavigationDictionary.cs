using System;
using Common.Serialization.SerializableDictionaries;
using Common.UI.Buttons;

namespace Menu.Common.Navigation
{
    [Serializable]
    public class NavigationDictionary : SerializableDictionary<ExtendedButton, NavigationEntry>
    {
        
    }
}