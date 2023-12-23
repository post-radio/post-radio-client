using System;
using System.Collections.Generic;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using GamePlay.Chat.Events;
using Global.System.MessageBrokers.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.Chat.UI
{
    [DisallowMultipleComponent]
    public class ChatUI : MonoBehaviour//, IScopeSwitchListener
    {
        [SerializeField] private ScrollRect _scroll;
        [SerializeField] private ChatUIInput _input;
        [SerializeField] private ChatUIMessageViewFactory _viewFactory;
        [SerializeField] private int _capacity = 100;

        private readonly List<IChatUIMessageView> _views = new();

        private IDisposable _receiveListener;

        // public void OnEnabled()
        // {
        //     _receiveListener = Msg.Listen<ChatMessageReceivedEvent>(OnMessageReceived);
        //     _input.Sumbit += SubmitMessage;
        // }
        //
        // public void OnDisabled()
        // {
        //     _receiveListener?.Dispose();
        //     _input.Sumbit -= SubmitMessage;
        // }
        //
        // private void OnMessageReceived(ChatMessageReceivedEvent payload)
        // {
        //     var view = _viewFactory.Create(payload.Player, payload.Message);
        //     _views.Add(view);
        //
        //     if (_views.Count >= _capacity)
        //     {
        //         var first = _views[0];
        //         _views.Remove(first);
        //         first.Destroy();
        //     }
        //
        //     var height = 0f;
        //
        //     foreach (var messageView in _views)
        //         height += messageView.GetHeight();
        //
        //     _viewFactory.UpdateContentSize(height, _views.Count);
        //     _scroll.normalizedPosition = Vector2.zero;
        // }
        //
        // private void SubmitMessage(string message)
        // {
        //     Msg.Publish(new ChatMessageSubmittedEvent(message));
        // }
    }
}