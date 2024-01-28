using System.Collections.Generic;
using Common.Architecture.Scopes.Runtime.Services;
using GamePlay.Chat.Common;
using GamePlay.Chat.Controller;
using GamePlay.Chat.InGame;
using GamePlay.Chat.UI;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Chat.Compose
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ChatRoutes.ComposeName, menuName = ChatRoutes.ComposePath)]
    public class ChatCompose : ScriptableObject, IServicesCompose
    {
        [SerializeField] private ChatControllerFactory _controller;
        [SerializeField] private ChatInGameFactory _inGame;
        [SerializeField] private ChatUIFactory _ui;

        public IReadOnlyList<IServiceFactory> Factories => new IServiceFactory[]
        {
            _controller,
            _inGame,
            _ui
        };
    }
}