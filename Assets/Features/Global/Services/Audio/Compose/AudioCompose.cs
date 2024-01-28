using System.Collections.Generic;
using Common.Architecture.Scopes.Runtime.Services;
using Global.Audio.Common;
using Global.Audio.Listener.Runtime;
using Global.Audio.Player.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Audio.Compose
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "GlobalAudioCompose", menuName = GlobalAudioAssetsPaths.Root + "Compose")]
    public class AudioCompose : ScriptableObject, IServicesCompose
    {
        [SerializeField] [Indent] private GlobalAudioListenerFactory _listener;
        [SerializeField] [Indent] private GlobalAudioPlayerFactory _player;
        
        public IReadOnlyList<IServiceFactory> Factories => new IServiceFactory[]
        {
            _listener,
            _player
        };
    }
}