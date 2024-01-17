using Nova;
using UnityEngine;

namespace Global.Localizations.Texts
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(TextBlock))]
    public class LocalizedText : MonoBehaviour
    {
        [SerializeField] private LanguageTextData _data;

        private TextBlock _text;

        private void Awake()
        {
            _text = GetComponent<TextBlock>();

            _data.AddCallback(OnLanguageChanged);
        }

        private void OnDestroy()
        {
            _data.RemoveCallback(OnLanguageChanged);
        }

        private void OnLanguageChanged(string text)
        {
            _text.Text = text;
        }
    }
}