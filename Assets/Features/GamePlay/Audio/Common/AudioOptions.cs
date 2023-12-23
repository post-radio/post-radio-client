using Internal.Services.Options.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Audio.Common
{
    [InlineEditor]
    public class AudioOptions : OptionsEntry
    {
        [SerializeField] private AudioBackendOptions _backend;
        [SerializeField] private AudioVoteOptions _vote;
        
        public AudioBackendOptions Backend => _backend;
        public AudioVoteOptions Vote => _vote;
    }
}