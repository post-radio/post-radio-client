using System;
using System.Collections.Generic;
using Common.DataTypes.Collections.NestedScriptableObjects.Attributes;
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
        private readonly HashSet<Action<string>> _localizeCallback = new();

        public void AddCallback(Action<string> localizeCallback)
        {
            _localizeCallback.Add(localizeCallback);

            if (_isInitialized == true)
                InvokeCallback();
        }
        
        public void RemoveCallback(Action<string> localizeCallback)
        {
            _localizeCallback.Remove(localizeCallback);
        }

        public void SelectLanguage(Language language)
        {
            _selected = language;
            _isInitialized = true;
            InvokeCallback();
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

        private void InvokeCallback()
        {
            var text = GetText();
            
            foreach (var callback in _localizeCallback)
                callback?.Invoke(text);
        }
    }
}