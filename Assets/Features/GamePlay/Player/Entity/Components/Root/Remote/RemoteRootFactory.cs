using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.Root.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Root.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = RootRoutes.RemoteComponentName, menuName = RootRoutes.RemoteComponentPath)]
    public class RemoteRootFactory : ScriptableObject, IComponentFactory
    {
        public async UniTask Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<RemoteRoot>()
                .As<IPlayerRoot>();
        }
    }
}