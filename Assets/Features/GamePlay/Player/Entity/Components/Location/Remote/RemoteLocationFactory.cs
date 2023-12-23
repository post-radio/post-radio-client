using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.EntityCreators.Runtime;
using Common.DataTypes.Collections.NestedScriptableObjects.Attributes;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.Common;
using GamePlay.Player.Entity.Components.Location.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Location.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LocationRoutes.RemoteComponentName, menuName = LocationRoutes.RemoteComponentPath)]
    public class RemoteLocationFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [NestedScriptableObjectField] private ShowAnimationFactory _showAnimation;
        [SerializeField] [NestedScriptableObjectField] private HideAnimationFactory _hideAnimation;
        
        public async UniTask Create(IServiceCollection services, IEntityUtils utils)
        {
            var showAnimation = _showAnimation.Create();
            var hideAnimation = _hideAnimation.Create();
            
            services.Register<RemoteLocation>()
                .As<IPlayerLocation>()
                .WithParameter(showAnimation)
                .WithParameter(hideAnimation)
                .AsProperty<RemoteLocation>();
        }
    }
}