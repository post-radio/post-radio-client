using System;
using Common.Serialization.NestedScriptableObjects.Attributes;
using Global.Localizations.Common;
using Global.Localizations.Definition;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Localizations.Texts
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LocalizationRoutes.DataName, menuName = LocalizationRoutes.DataPath)]
    public class LanguageTextData : ScriptableObject
    {
        [SerializeField] [NestedScriptableObjectField] [Indent] private LanguageEntry _ru;

        [SerializeField] [NestedScriptableObjectField] [Indent] private LanguageEntry _eng;

        private Language _selected;
        private bool _isInitialized;
        private Action<string> _localizeCallback;

        public void AttachText(Action<string> localizeCallback)
        {
            _localizeCallback = localizeCallback;

            if (_isInitialized == true)
                _localizeCallback?.Invoke(GetText());
        }

        public void SelectLanguage(Language language)
        {
            _selected = language;
            _isInitialized = true;
            _localizeCallback?.Invoke(GetText());
        }

        public string GetText()
        {
            return _selected switch
            {
                Language.Ru => _ru.Text,
                Language.Eng => _eng.Text,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}