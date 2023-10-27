using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.EntityCreators.Runtime;
using GamePlay.Player.Entity.Components.Visual.View;
using UnityEngine;

namespace GamePlay.Player.Entity.Setup.Local
{
    [DisallowMultipleComponent]
    public class LocalPlayerViewFactory : EntitySetupView, IEntityViewFactory
    {
        [SerializeField] private PlayerView _view;
        [SerializeField] private Animator _animator;
        
        public override void CreateViews(IServiceCollection services, IEntityUtils utils)
        {
            services.RegisterComponent(_view)
                .As<IPlayerView>();

            services.RegisterComponent(_animator);
        }
    }
}