using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Global.Services.Backend.Abstract
{
    public interface IBackendClient
    {
        UniTask<T> Get<T>(IGetRequest request);
        UniTask<string> GetRaw(IGetRequest request);
        UniTask<T> Post<T>(IPostRequest request);
        UniTask<AudioClip> GetAudio(IGetRequest request, AudioType audioType);
        UniTask<Texture2D> GetImage(IGetRequest request);
    }
}