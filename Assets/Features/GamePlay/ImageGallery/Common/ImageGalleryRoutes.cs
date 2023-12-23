using GamePlay.Common.Paths;

namespace GamePlay.ImageGallery.Common
{
    public class ImageGalleryRoutes
    {
        private const string Path = GamePlayAssetsPaths.Root + "ImageGallery/";
        private const string Name = GamePlayAssetsPrefixes.Service + "ImageGallery_";

        public const string ComposePath = Path + "Compose";
        public const string ComposeName = Name + "Compose";
    }
}