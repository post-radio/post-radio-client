using Common.Architecture.Container.Abstract;
using GamePlay.Common.SceneBootstrappers.Runtime;
using GamePlay.House.Composition;
using GamePlay.House.Root;
using UnityEngine;

namespace GamePlay.House.Bootstrap
{
    [DisallowMultipleComponent]
    public class HouseViewsRegister : SceneComponentRegister
    {
        [SerializeField] private HouseCompositor _compositor;
        [SerializeField] private HouseView _view;
        
        public override void Register(IServiceCollection builder)
        {
            builder.RegisterComponent(_compositor)
                .As<IHouseCompositor>();
            
            builder.RegisterComponent(_view)
                .As<IHouseView>();
        }
    }
}