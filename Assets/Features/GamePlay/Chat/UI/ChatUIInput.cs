using System;
using TMPro;
using UnityEngine;

namespace GamePlay.Chat.UI
{
    [DisallowMultipleComponent]
    public class ChatUIInput : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _input;

        public event Action<string> Sumbit;

        private void OnEnable()
        {
            _input.onSubmit.AddListener(OnSubmit);
        }
        
        private void OnDisable()
        {
            _input.onSubmit.RemoveListener(OnSubmit);
        }

        private void OnSubmit(string text)
        {
            _input.text = string.Empty;
            Sumbit?.Invoke(text);
            _input.ActivateInputField();
        }
    }
}