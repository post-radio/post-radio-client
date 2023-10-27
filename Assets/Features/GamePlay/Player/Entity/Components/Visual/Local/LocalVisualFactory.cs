using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.EntityCreators.Runtime;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.Common;
using GamePlay.Player.Entity.Components.Visual.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Visual.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = VisualRoutes.LocalComponentName, menuName = VisualRoutes.LocalComponentPath)]
    public class LocalVisualFactory : ScriptableObject, IComponentFactory
    {
        public async UniTask Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<LocalVisual>()
                .As<IPlayerVisual>()
                .AsProperty<LocalVisual>();
        }
    }
}