using System;
using System.Text;
using System.Threading;
using Cysharp.Threading.Tasks;
using Global.Backend.Abstract;
using Global.Backend.Logs;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace Global.Backend.Runtime
{
    public class BackendClient : IBackendClient
    {
        public BackendClient(BackendLogger logger)
        {
            _logger = logger;
        }

        private readonly BackendLogger _logger;

        public async UniTask<T> Get<T>(IGetRequest request, CancellationToken cancellation)
        {
            var responseContent = await GetRaw(request, cancellation);
            var result = JsonConvert.DeserializeObject<T>(responseContent);

            return result;
        }

        public async UniTask<string> GetRaw(IGetRequest request, CancellationToken cancellation)
        {
            _logger.OnGetRequest(request);
            using var downloadHandlerBuffer = new DownloadHandlerBuffer();
            using var webRequest = new UnityWebRequest(request.Uri, "GET", downloadHandlerBuffer, null);

            foreach (var header in request.Headers)
                webRequest.SetRequestHeader(header.Type, header.Value);

            await webRequest.SendWebRequest().ToUniTask(cancellationToken: cancellation);

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                _logger.OnGetError(request, webRequest.error);
                throw new Exception("GET request failed");
            }

            var responseContent = downloadHandlerBuffer.text;
            _logger.OnGetResponse(request, responseContent);

            return responseContent;
        }

        public async UniTask<T> Post<T>(IPostRequest request, CancellationToken cancellation)
        {
            _logger.OnPostRequest(request);

            using var downloadHandlerBuffer = new DownloadHandlerBuffer();
            UploadHandlerRaw uploadHandler = null;

            if (request.Body != null)
                uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(request.Body));

            using var webRequest = new UnityWebRequest(request.Uri, "POST", downloadHandlerBuffer, uploadHandler);

            foreach (var header in request.Headers)
                webRequest.SetRequestHeader(header.Type, header.Value);

            await webRequest.SendWebRequest().ToUniTask(cancellationToken: cancellation);

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                _logger.OnPostError(request, webRequest.error);
                throw new Exception("POST request failed");
            }

            var responseContent = downloadHandlerBuffer.text;
            _logger.OnPostResponse(request, responseContent);
            var result = JsonConvert.DeserializeObject<T>(responseContent);

            uploadHandler?.Dispose();

            return result;
        }

        public async UniTask<AudioClip> GetAudio(IGetRequest request, AudioType audioType, CancellationToken cancellation)
        {
            _logger.OnGetRequest(request);

            using var downloadHandlerAudioClip = new DownloadHandlerAudioClip(request.Uri, audioType);
            using var webRequest = new UnityWebRequest(request.Uri, "GET", downloadHandlerAudioClip, null);

            foreach (var header in request.Headers)
                webRequest.SetRequestHeader(header.Type, header.Value);

            await webRequest.SendWebRequest().ToUniTask(cancellationToken: cancellation);

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                _logger.OnGetError(request, webRequest.error);
                throw new Exception("GET request failed");
            }
            
            _logger.OnAudioResponse(request);

            return downloadHandlerAudioClip.audioClip;
        }

        public async UniTask<Texture2D> GetImage(IGetRequest request, CancellationToken cancellation)
        {
            _logger.OnGetRequest(request);

            using var downloadHandler = new DownloadHandlerTexture(true);
            using var webRequest = new UnityWebRequest(request.Uri, "GET",  downloadHandler, null);
            await webRequest.SendWebRequest().ToUniTask(cancellationToken: cancellation);

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                _logger.OnGetError(request, webRequest.error);
                throw new Exception("GET request failed");
            }
            
            _logger.OnImageResponse(request);

            return downloadHandler.texture;
        }
    }
}