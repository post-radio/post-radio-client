using Common.UI.Buttons;
using Global.GameLoops.Events;
using Global.System.MessageBrokers.Runtime;
using TMPro;
using UnityEngine;

namespace Global.UI.Overlays.Runtime
{
    [DisallowMultipleComponent]
    public class GlobalExceptionView : MonoBehaviour, IGlobalExceptionView
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private ExtendedButton _button;

        private void OnEnable()
        {
            _button.Clicked += OnRestartClicked;
        }

        private void OnDisable()
        {
            _button.Clicked -= OnRestartClicked;
        }

        public void Show(string exception)
        {
            gameObject.SetActive(true);
            _text.text = exception;
        }

        private void OnRestartClicked()
        {
            gameObject.SetActive(false);
            Msg.Publish(new GameRestartRequest());
        }
    }
}