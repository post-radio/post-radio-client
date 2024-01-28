using System.Collections.Generic;
using Common.Architecture.Scopes.Runtime.Services;
using GamePlay.Audio.Backend;
using GamePlay.Audio.Common;
using GamePlay.Audio.Controller;
using GamePlay.Audio.Player.Common;
using GamePlay.Audio.Sync;
using GamePlay.Audio.UI.Root;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Audio.Compose
{
    [InlineEditor]
    [CreateAssetMenu(fileName = AudioRoutes.ComposeName, menuName = AudioRoutes.ComposePath)]
    public class AudioCompose : ScriptableObject, IServicesCompose
    {
        [SerializeField] private AudioControllerFactory _controller;
        [SerializeField] private AudioUIFactory _ui;
        [SerializeField] private AudioPlayerFactory _player;
        [SerializeField] private AudioBackendFactory _backend;
        [SerializeField] private AudioSyncFactory _sync;
        
        public IReadOnlyList<IServiceFactory> Factories => new IServiceFactory[]
        {
            _controller,
            _ui,
            _player,
            _backend,
            _sync
        };
    }
}