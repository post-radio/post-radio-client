using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Global.UI.Overlays.Common;
using Internal.Services.Scenes.Data;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.UI.Overlays.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = OverlayRouter.ServiceName,
        menuName = OverlayRouter.ServicePath)]
    public class OverlayAsset : ScriptableObject, IServiceFactory
    {
        [SerializeField] private SceneData _scene;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var result = await utils.SceneLoader.LoadTyped<OverlayBootstrapper>(_scene);

            var bootstrapper = result.Searched;

            foreach (var listener in bootstrapper.EventListeners)
                utils.Callbacks.Listen(listener);
        }
    }
}