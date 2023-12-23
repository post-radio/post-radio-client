using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.ImageGallery.Backend;
using GamePlay.ImageGallery.Common;
using GamePlay.ImageGallery.Controller;
using Global.Backend.Options;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.ImageGallery.Compose
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ImageGalleryRoutes.ComposeName, menuName = ImageGalleryRoutes.ComposePath)]
    public class ImageGalleryFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var backendOptions = utils.Options.GetOptions<BackendOptions>();
            var galleryOptions = utils.Options.GetOptions<ImageGalleryOptions>();

            services.Register<ImageGalleryBackend>()
                .WithParameter(backendOptions)
                .As<IImageGalleryBackend>();

            services.Register<ImageGalleryController>()
                .WithParameter(galleryOptions)
                .AsCallbackListener();
        }
    }
}