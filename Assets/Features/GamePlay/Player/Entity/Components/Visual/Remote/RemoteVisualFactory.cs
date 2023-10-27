using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.EntityCreators.Runtime;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.Common;
using GamePlay.Player.Entity.Components.Visual.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Visual.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = VisualRoutes.RemoteComponentName, menuName = VisualRoutes.RemoteComponentPath)]
    public class RemoteVisualFactory : ScriptableObject, IComponentFactory
    {
        public async UniTask Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<RemoteVisual>()
                .As<IPlayerVisual>()
                .AsProperty<RemoteVisual>();
        }
    }
}