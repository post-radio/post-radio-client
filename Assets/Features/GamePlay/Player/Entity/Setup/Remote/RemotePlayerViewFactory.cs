using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.Components.Visual.View;
using UnityEngine;

namespace GamePlay.Player.Entity.Setup.Remote
{
    [DisallowMultipleComponent]
    public class RemotePlayerViewFactory : EntitySetupView
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