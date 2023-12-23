using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GamePlay.ImageGallery.UI
{
    public interface IImageGalleryView
    {
        void Open();
        void Close();
        UniTask SetImage(Texture2D image);
    }
}