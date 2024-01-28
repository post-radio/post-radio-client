using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.Animators.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Animators.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = AnimatorRoutes.ComponentName, menuName = AnimatorRoutes.ComponentPath)]
    public class AnimatorFactory : ScriptableObject, IComponentFactory
    {
        public async UniTask Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<PlayerAnimator>()
                .As<IPlayerAnimator>();
        }
    }
}