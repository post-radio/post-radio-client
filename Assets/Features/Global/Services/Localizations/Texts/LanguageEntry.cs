using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Localizations.Texts
{
    [InlineEditor]
    public class LanguageEntry : ScriptableObject
    {
        [SerializeField] private string _text;

        public string Text => _text;
    }
}