using System.Text;
using GamePlay.Audio.Common;
using Global.Backend.Options;

namespace GamePlay.Audio.Backend
{
    public class BackendRoutes : IBackendRoutes
    {
        public BackendRoutes(AudioOptions audioOptions, BackendOptions backendOptions)
        {
            _storage = audioOptions.Backend.Storage;
            _getLink = backendOptions.StreamingApiUrl + audioOptions.Backend.GetLink;
            _validation = backendOptions.StreamingApiUrl + audioOptions.Backend.Validation;
            _playlist = backendOptions.StreamingApiUrl + audioOptions.Backend.Playlist;

            _stringBuilder = new StringBuilder();
        }
        
        private readonly string _storage;
        private readonly string _getLink;
        private readonly string _validation;
        private readonly string _playlist;

        private readonly StringBuilder _stringBuilder;

        public string AudioStorage(string audioLink)
        {
            _stringBuilder.Clear();
            
            _stringBuilder.Append(_storage);
            _stringBuilder.Append(audioLink);

            return _stringBuilder.ToString();
        }

        public string GetAudioLink()
        {
            return _getLink;
        }

        public string LinkValidation()
        {
            return _validation;
        }

        public string Playlist()
        {
            return _playlist;
        }
    }
}