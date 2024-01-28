using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Common.Tools.UniversalAnimators.Updaters.Common;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Common.Tools.UniversalAnimators.Updaters.Runtime
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