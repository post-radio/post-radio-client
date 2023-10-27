using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Relocation.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Relocation.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = RelocationRoutes.ServiceName, menuName = RelocationRoutes.ServicePath)]
    public class RelocationFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<Relocation>()
                .As<IRelocation>()
                .AsCallbackListener();
        }
    }
}