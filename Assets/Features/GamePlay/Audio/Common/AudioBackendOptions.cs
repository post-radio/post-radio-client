using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Audio.Common
{
    [InlineEditor]
    [CreateAssetMenu(fileName = AudioRoutes.BackendRoutesName, menuName = AudioRoutes.BackendRoutesPath)]
    public class AudioBackendOptions : ScriptableObject
    {
        [SerializeField] private string _storage;
        [SerializeField] private string _getLink;
        [SerializeField] private string _validation;
        [SerializeField] private string _playlist;
        [SerializeField] private string _contentFormat;

        public string Storage => _storage;
        public string GetLink => _getLink;
        public string Validation => _validation;
        public string Playlist => _playlist;
    }
}