using GamePlay.Player.Entity.Definition;
using TMPro;
using UnityEngine;

namespace GamePlay.Chat.UI
{
    [DisallowMultipleComponent]
    public class ChatUIMessageView : MonoBehaviour, IChatUIMessageView
    {
        [SerializeField] private TMP_Text _sender;
        [SerializeField] private TMP_Text _message;
        [SerializeField] [Min(0f)] private float _additionalHeight = 50f;

        public void Construct(INetworkPlayer player, string message)
        {
            _sender.text = player.DisplayName;
            _message.text = message;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        public float GetHeight()
        {
            return _message.GetPreferredValues().y + _additionalHeight;
        }
    }
}