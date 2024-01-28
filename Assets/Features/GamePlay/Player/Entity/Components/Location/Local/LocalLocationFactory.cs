using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using Common.DataTypes.Collections.NestedScriptableObjects.Attributes;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.Common;
using GamePlay.Player.Entity.Components.Location.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Location.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LocationRoutes.LocalComponentName, menuName = LocationRoutes.LocalComponentPath)]
    public class LocalLocationFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [NestedScriptableObjectField] private ShowAnimationFactory _showAnimation;
        [SerializeField] [NestedScriptableObjectField] private HideAnimationFactory _hideAnimation;
        
        public async UniTask Create(IServiceCollection services, IEntityUtils utils)
        {
            var showAnimation = _showAnimation.Create();
            var hideAnimation = _hideAnimation.Create();
            
            services.Register<LocalLocation>()
                .As<IPlayerLocation>()
                .WithParameter(showAnimation)
                .WithParameter(hideAnimation)
                .AsProperty<LocalLocation>();
        }
    }
}