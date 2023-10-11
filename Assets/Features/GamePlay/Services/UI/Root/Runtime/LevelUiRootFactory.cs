using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Services.UI.Root.Common;
using Global.UI.UiStateMachines.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Services.UI.Root.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LevelUiRootRoutes.ServiceName,
        menuName = LevelUiRootRoutes.ServicePath)]
    public class LevelUiRootFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private UiConstraints _constraints;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<LevelUiRoot>()
                .WithParameter(_constraints)
                .As<ILevelUiRoot>();
        }
    }
}