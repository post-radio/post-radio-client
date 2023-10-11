using System;
using Common.UI.Buttons;
using Global.Localizations.Definition;
using Menu.Common.Navigation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Settings.UI
{
    [DisallowMultipleComponent]
    public class SettingsView : MonoBehaviour, ISettingsView
    {
        [SerializeField] private TMP_Dropdown _languageDropdown;
        [SerializeField] private Slider _musicSlider;
        [SerializeField] private Slider _soundSlider;

        [SerializeField] private ExtendedButton _socialButton;
        
        private ITabNavigation _navigation;
        private RectTransform _transform;
        
        public ITabNavigation Navigation => _navigation;
        public RectTransform Transform => _transform;

        public float MusicValue => _musicSlider.value;
        public float SoundValue => _soundSlider.value;

        public event Action<Language> LanguageChanged;
        public event Action SocialClicked;
        
        private void Awake()
        {
            _navigation = GetComponent<ITabNavigation>();
            _transform = GetComponent<RectTransform>();
        }

        private void OnEnable()
        {
            _socialButton.Clicked += OnSocialClicked;
            _languageDropdown.onValueChanged.AddListener(OnLanguageChanged);
        }
        
        private void OnDisable()
        {
            _socialButton.Clicked -= OnSocialClicked;
        }
        
        public void SetSlidersValue(float music, float sounds)
        {
            _musicSlider.value = music;
            _soundSlider.value = sounds;
        }

        public void SetLanguage(Language language)
        {
            _languageDropdown.value = (int)language;
        }

        private void OnLanguageChanged(int value)
        {
            var language = (Language)value;
            LanguageChanged?.Invoke(language);
        }

        private void OnSocialClicked()
        {
            SocialClicked?.Invoke();    
        }
    }
}