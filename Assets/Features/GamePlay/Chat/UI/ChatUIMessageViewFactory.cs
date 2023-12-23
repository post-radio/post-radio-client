using GamePlay.Player.Entity.Definition;
using UnityEngine;

namespace GamePlay.Chat.UI
{
    [DisallowMultipleComponent]
    public class ChatUIMessageViewFactory : MonoBehaviour
    {
        [SerializeField] private RectTransform _content;
        [SerializeField] private ChatUIMessageView _prefab;
        [SerializeField] [Min(0f)] private float _offset;
        
        public IChatUIMessageView Create(INetworkPlayer player, string message)
        {
            var view = Instantiate(_prefab, _content);
            view.Construct(player, message);
            var height = view.GetHeight();
            var viewTransform = view.GetComponent<RectTransform>();
            var sizeDelta = viewTransform.sizeDelta;
            sizeDelta = new Vector2(sizeDelta.x, height);
            viewTransform.sizeDelta = sizeDelta;
            
            return view;
        }

        public void UpdateContentSize(float height, int elementsCount)
        {
            var sizeDelta = _content.sizeDelta;
            sizeDelta = new Vector2(sizeDelta.x, height + _offset * elementsCount);
            _content.sizeDelta = sizeDelta;
        }
    }   
}