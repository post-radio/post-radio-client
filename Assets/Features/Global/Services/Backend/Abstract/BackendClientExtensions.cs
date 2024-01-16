using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;

namespace Global.Services.Backend.Abstract
{
    public static class BackendClientExtensions
    {
        public static UniTask<T> Get<T>(this IBackendClient client, string uri, params IRequestHeader[] headers)
        {
            var request = new GetRequest(uri, headers);

            return client.Get<T>(request);
        }
        
        public static UniTask<string> GetRaw(this IBackendClient client, string uri, params IRequestHeader[] headers)
        {
            var request = new GetRequest(uri, headers);

            return client.GetRaw(request);
        }

        public static UniTask<TResponse> Post<TResponse, TBody>(
            this IBackendClient client,
            string uri,
            TBody body,
            params IRequestHeader[] headers)
        {
            var bodyJson = JsonConvert.SerializeObject(body);
            var request = new PostRequest(uri, bodyJson, headers);

            return client.Post<TResponse>(request);
        }

        public static UniTask<TResponse> Post<TResponse>(
            this IBackendClient client,
            string uri,
            params IRequestHeader[] headers)
        {
            var request = new PostRequest(uri, null, headers);

            return client.Post<TResponse>(request);
        }

        public static UniTask<AudioClip> GetAudio(
            this IBackendClient client,
            string uri,
            params IRequestHeader[] headers)
        {
            var request = new GetRequest(uri, headers);

            return client.GetAudio(request, AudioType.MPEG);
        }

        public static UniTask<Texture2D> GetImage(
            this IBackendClient client,
            string uri,
            params IRequestHeader[] headers)
        {
            var request = new GetRequest(uri, headers);

            return client.GetImage(request);
        }
    }
}