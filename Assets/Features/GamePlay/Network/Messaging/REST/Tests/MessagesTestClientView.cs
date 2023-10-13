using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.Network.Messaging.REST.Tests
{
    [DisallowMultipleComponent]
    public class MessagesTestClientView : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _value;
        [SerializeField] private TMP_InputField _input;

        public int Value => int.Parse(_input.text);
        
        public event Action<int> SendClicked;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnSendClicked);
        }
        
        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnSendClicked);
        }

        public void SetName(string playerName)
        {
            _name.text = playerName;
        }

        public void SetValue(int value)
        {
            _value.text = value.ToString();
        }

        private void OnSendClicked()
        {
            SendClicked?.Invoke(int.Parse(_input.text));
        }
    }
}