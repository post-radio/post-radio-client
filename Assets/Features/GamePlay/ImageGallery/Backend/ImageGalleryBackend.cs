using System;
using Cysharp.Threading.Tasks;
using Global.Backend.Options;
using UnityEngine;
using UnityEngine.Networking;

namespace GamePlay.ImageGallery.Backend
{
    public class ImageGalleryBackend : IImageGalleryBackend
    {
        public ImageGalleryBackend(BackendOptions backendOptions)
        {
            _backendOptions = backendOptions;
        }

        private readonly BackendOptions _backendOptions;

        public async UniTask<Texture2D> LoadRandom()
        {
            var uri = await GetLink();

            if (uri == string.Empty)
                return null;
            
            using var downloadHandler = new DownloadHandlerTexture(true);
            using var request = new UnityWebRequest(uri, "GET",  downloadHandler, null);
            await request.SendWebRequest().ToUniTask();

            if (request.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError(request.error);
                return null;
            }

            return downloadHandler.texture;
        }

        private async UniTask<string> GetLink()
        {
            var uri = _backendOptions.StreamingApiUrl + "images/random";
            using var downloadHandlerBuffer = new DownloadHandlerBuffer();
            using var webRequest = new UnityWebRequest(uri, "GET", downloadHandlerBuffer, null);

            await webRequest.SendWebRequest().ToUniTask();

            if (webRequest.result != UnityWebRequest.Result.Success)
                throw new Exception($"Failed to get image link with url: {uri}");

            var link = webRequest.downloadHandler.text;

            return link;
        }
    }
}