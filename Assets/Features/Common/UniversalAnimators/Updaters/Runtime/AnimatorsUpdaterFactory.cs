using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Common.UniversalAnimators.Updaters.Common;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Common.UniversalAnimators.Updaters.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = AnimatorsUpdaterRoutes.ServiceName, menuName = AnimatorsUpdaterRoutes.ServicePath)]
    public class AnimatorsUpdaterFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<AnimatorsUpdater>()
                .As<IAnimatorsUpdater>()
                .AsCallbackListener();
        }
    }
}