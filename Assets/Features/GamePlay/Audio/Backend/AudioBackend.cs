using System.Threading;
using Cysharp.Threading.Tasks;
using GamePlay.Audio.Backend.Objects;
using GamePlay.Audio.Definitions;
using Global.Backend.Abstract;
using UnityEngine;

namespace GamePlay.Audio.Backend
{
    public class AudioBackend : IAudioBackend
    {
        public AudioBackend(IBackendClient client, IBackendRoutes routes)
        {
            _client = client;
            _routes = routes;
        }

        private readonly IBackendClient _client;
        private readonly IBackendRoutes _routes;

        public async UniTask<UrlValidationResult> ValidateUrl(string audioUrl, CancellationToken cancellation)
        {
            var uri = $"{_routes.LinkValidation()}?AudioUrl={audioUrl}";
            var result = await _client.Get<UrlValidationResponse>(uri, false, cancellation);

            if (result.IsValid == false || result.Metadata == null)
                return new UrlValidationResult { IsValid = false };

            return new UrlValidationResult
            {
                IsValid = result.IsValid,
                Metadata = new AudioMetadata(result.Metadata.Url, result.Metadata.Author, result.Metadata.Name)
            };
        }

        public async UniTask<StoredAudio> GetAudioLink(AudioMetadata metadata, CancellationToken cancellation)
        {
            var uri = $"{_routes.GetAudioLink()}?AudioUrl={metadata.Url}";
            var result = await _client.Get<AudioLinkResponse>(uri, true, cancellation);

            return new StoredAudio(result.AudioUrl, metadata);
        }

        public async UniTask<RandomTracksResult> GetRandomTracks(CancellationToken cancellation)
        {
            var body = new RandomTracksRequest
            {
                IncludedPlaylists = new[] { "alternative", "original" }
            };

            var uri = _routes.Playlist();   
            var result = await _client.Post<RandomTracksResponse, RandomTracksRequest>(
                uri,
                body,
                false,
                cancellation,
                RequestHeader.Json());

            return RandomTracksResult.ToResult(result.Tracks);
        }

        public UniTask<AudioClip> LoadTrack(StoredAudio audio, CancellationToken cancellation)
        {
            var uri = _routes.AudioStorage(audio.Link);
            return _client.GetAudio(uri, true, cancellation);
        }
    }
}