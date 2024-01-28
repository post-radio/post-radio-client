using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.Common;
using GamePlay.Player.Entity.Components.Identity.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Identity.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = IdentityRoutes.LocalComponentName, menuName = IdentityRoutes.LocalComponentPath)]
    public class LocalIdentityFactory : ScriptableObject, IComponentFactory
    {
        public async UniTask Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<LocalIdentity>()
                .As<IPlayerIdentity>()
                .AsProperty<LocalIdentity>();
        }
    }
}