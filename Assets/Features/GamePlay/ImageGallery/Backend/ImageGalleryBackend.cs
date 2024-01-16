using Cysharp.Threading.Tasks;
using Global.Backend.Options;
using Global.Services.Backend.Abstract;
using UnityEngine;

namespace GamePlay.ImageGallery.Backend
{
    public class ImageGalleryBackend : IImageGalleryBackend
    {
        public ImageGalleryBackend(IBackendClient client, BackendOptions backendOptions)
        {
            _client = client;
            _backendOptions = backendOptions;
        }

        private readonly IBackendClient _client;
        private readonly BackendOptions _backendOptions;

        public async UniTask<Texture2D> LoadRandom()
        {
            var uri = await GetLink();

            if (uri == string.Empty)
                return null;

            var image = await _client.GetImage(uri);

            return image;
        }

        private async UniTask<string> GetLink()
        {
            var uri = _backendOptions.StreamingApiUrl + "images/random";
            var result = await _client.GetRaw(uri);

            return result;
        }
    }
}