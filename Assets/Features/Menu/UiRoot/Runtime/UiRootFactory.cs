using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Common.DataTypes.Collections.NestedScriptableObjects.Attributes;
using Cysharp.Threading.Tasks;
using Internal.Services.Scenes.Data;
using Menu.Common.Navigation;
using Menu.UiRoot.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.UiRoot.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = UiRootRoutes.ServiceName,
        menuName = UiRootRoutes.ServicePath)]
    public class UiRootFactory : BaseUiRootFactory
    {
        [SerializeField] [NestedScriptableObjectField] private SceneData _scene;
        
        public override async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var sceneData = await utils.SceneLoader.LoadTyped<MenuUiLinker>(_scene);
            var linker = sceneData.Searched;

            for (var i = 0; i < linker.Root.childCount; i++)
                linker.Root.GetChild(i).gameObject.SetActive(true);

            services.RegisterInstance(linker.About);
            services.RegisterInstance(linker.Main);
            services.RegisterInstance(linker.Settings);
            services.RegisterInstance(linker.TabTransitionPoints);

            var navigations = FindObjectsByType<TabNavigation>(FindObjectsSortMode.None);

            foreach (var navigation in navigations)
                services.Inject(navigation);
        }
    }
}