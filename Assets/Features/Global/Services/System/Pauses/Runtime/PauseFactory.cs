using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Global.System.Pauses.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.System.Pauses.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = PauseRoutes.ServiceName, menuName = PauseRoutes.ServicePath)]
    public class PauseFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<PauseSwitcher>()
                .As<IPause>();
        }
    }
}