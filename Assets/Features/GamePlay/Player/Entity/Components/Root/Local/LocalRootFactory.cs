using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.EntityCreators.Runtime;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.Root.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Root.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = RootRoutes.LocalComponentName, menuName = RootRoutes.LocalComponentPath)]
    public class LocalRootFactory : ScriptableObject, IComponentFactory
    {
        public async UniTask Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<LocalRoot>()
                .As<IPlayerRoot>();
        }
    }
}