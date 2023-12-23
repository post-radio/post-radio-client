using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GamePlay.ImageGallery.Backend
{
    public interface IImageGalleryBackend
    {
        UniTask<Texture2D> LoadRandom();
    }
}