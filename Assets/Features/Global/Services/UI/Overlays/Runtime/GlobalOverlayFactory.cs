using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Global.UI.Localizations.Texts;
using Global.UI.Overlays.Common;
using Internal.Services.Scenes.Data;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.UI.Overlays.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = OverlayRouter.ServiceName,
        menuName = OverlayRouter.ServicePath)]
    public class GlobalOverlayFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private SceneData _scene;
        [SerializeField] private LanguageTextData _localization;
        
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            // var result = await utils.SceneLoader.LoadTyped<GlobalOverlayView>(_scene);
            //
            // var view = result.Searched;

            services.Register<GlobalExceptionController>()
//                .WithParameter(view.ExceptionView)
                .WithParameter(_localization)
                .As<IGlobalExceptionController>();
        }
    }
}