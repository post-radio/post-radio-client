using System;
using Global.Localizations.Definition;
using Menu.Common.Navigation;
using UnityEngine;

namespace Menu.Settings.UI
{
    public interface ISettingsView
    {
        ITabNavigation Navigation { get; }
        RectTransform Transform { get; }
        
        float MusicValue { get; }
        float SoundValue { get; }

        event Action<Language> LanguageChanged;

        void SetSlidersValue(float music, float sounds);
        void SetLanguage(Language language);
    }
}