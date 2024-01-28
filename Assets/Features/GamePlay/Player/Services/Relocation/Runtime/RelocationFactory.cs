using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Services.Relocation.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Services.Relocation.Runtime
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