using System;
using Global.UI.Localizations.Definition;
using Menu.Common.Navigation;
using NovaSamples.UIControls;
using UnityEngine;

namespace Menu.Settings.UI
{
    [DisallowMultipleComponent]
    public class SettingsView : MonoBehaviour, ISettingsView
    {
        [SerializeField] private Dropdown _languageDropdown;
        [SerializeField] private Slider _musicSlider;
        [SerializeField] private Slider _soundSlider;

        private ITabNavigation _navigation;
        private RectTransform _transform;

        public ITabNavigation Navigation => _navigation;
        public RectTransform Transform => _transform;

        public float MusicValue => _musicSlider.Value;
        public float SoundValue => _soundSlider.Value;

        public event Action<Language> LanguageChanged;

        private void Awake()
        {
            _navigation = GetComponent<ITabNavigation>();
            _transform = GetComponent<RectTransform>();
        }

        private void OnEnable()
        {
            _languageDropdown.OnValueChanged.AddListener(OnLanguageChanged);
        }

        private void OnDisable()
        {
            _languageDropdown.OnValueChanged.RemoveListener(OnLanguageChanged);
        }
        
        public void OnActivate(float music, float sounds, Language language)
        {
            _musicSlider.Value = music;
            _soundSlider.Value = sounds;
            _languageDropdown.Visuals.InitSelectionLabel(language.ToString());
            _languageDropdown.DropdownOptions.SelectedIndex = (int)language;
        }

        public void OnDeactivate()
        {
        }

        private void OnLanguageChanged(string value)
        {
            var language = LanguageExtensions.ParseLanguage(value);
            LanguageChanged?.Invoke(language);
        }
    }
}