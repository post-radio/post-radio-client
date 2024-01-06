using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using GamePlay.Audio.Backend.Objects;
using GamePlay.Audio.Definitions;
using Newtonsoft.Json;
using UnityEngine.Networking;

namespace GamePlay.Audio.Backend
{
    public class AudioBackend : IAudioBackend
    {
        public AudioBackend(IBackendRoutes routes)
        {
            _routes = routes;
        }

        private readonly IBackendRoutes _routes;

        public async UniTask<UrlValidationResult> ValidateUrl(string audioUrl, CancellationToken cancellation)
        {
            var uri = $"{_routes.LinkValidation()}?AudioUrl={audioUrl}";

            using var downloadHandlerBuffer = new DownloadHandlerBuffer();
            using var webRequest = new UnityWebRequest(uri, "GET", downloadHandlerBuffer, null);
            await webRequest.SendWebRequest().ToUniTask(cancellationToken: cancellation);

            if (webRequest.result != UnityWebRequest.Result.Success)
                throw new Exception($"Failed to execute url validation with params: {uri}/{audioUrl}");

            var responseContent = downloadHandlerBuffer.text;
            var result = JsonConvert.DeserializeObject<UrlValidationResponse>(responseContent);

            if (result.IsValid == false || result.Metadata == null)
                return new UrlValidationResult { IsValid = false };

            return new UrlValidationResult
            {
                IsValid = result.IsValid,
                Metadata = new AudioMetadata(result.Metadata.Url, result.Metadata.Author, result.Metadata.Name)
            };
        }

        public async UniTask<StoredAudio> GetAudioLink(AudioMetadata metadata)
        {
            var uri = $"{_routes.GetAudioLink()}?AudioUrl={metadata.Url}";
            using var downloadHandlerBuffer = new DownloadHandlerBuffer();
            using var webRequest = new UnityWebRequest(uri, "GET", downloadHandlerBuffer, null);
            await webRequest.SendWebRequest().ToUniTask();

            if (webRequest.result != UnityWebRequest.Result.Success)
                throw new Exception($"Failed to get audio link with params: {uri}/{metadata.Url}");

            var responseContent = downloadHandlerBuffer.text;
            var result = JsonConvert.DeserializeObject<AudioLinkResponse>(responseContent);

            return new StoredAudio(result.AudioUrl, metadata);
        }

        public async UniTask<RandomTracksResult> GetRandomTracks()
        {
            var uri = _routes.Playlist();
            using var downloadHandlerBuffer = new DownloadHandlerBuffer();
            using var webRequest = new UnityWebRequest(uri, "GET", downloadHandlerBuffer, null);

            await webRequest.SendWebRequest().ToUniTask();

            if (webRequest.result != UnityWebRequest.Result.Success)
                throw new Exception($"Failed to execute url validation with url: {_routes.Playlist()}");

            var responseContent = downloadHandlerBuffer.text;
            var result = JsonConvert.DeserializeObject<RandomTracksResponse>(responseContent);

            var results = new List<AudioMetadata>();

            foreach (var rawMetadata in result.Tracks)
                results.Add(new AudioMetadata(rawMetadata.Url, rawMetadata.Author, rawMetadata.Name));
                
            return new RandomTracksResult
            {
                Tracks = results
            };
        }
    }
}