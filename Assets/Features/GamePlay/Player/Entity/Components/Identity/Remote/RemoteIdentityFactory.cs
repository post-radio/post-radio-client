using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.Common;
using GamePlay.Player.Entity.Components.Identity.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Identity.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = IdentityRoutes.RemoteComponentName, menuName = IdentityRoutes.RemoteComponentPath)]
    public class RemoteIdentityFactory : ScriptableObject, IComponentFactory
    {
        public async UniTask Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<RemoteIdentity>()
                .As<IPlayerIdentity>()
                .AsProperty<RemoteIdentity>();
        }
    }
}