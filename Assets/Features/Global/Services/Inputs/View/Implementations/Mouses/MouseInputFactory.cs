using Common.Architecture.Container.Abstract;
using Global.Inputs.View.Common;
using Global.Inputs.View.Runtime.Sources;
using UnityEngine;

namespace Global.Inputs.View.Implementations.Mouses
{
    [CreateAssetMenu(
        fileName = InputViewRoutes.InputSourcePrefix + "Mouse",
        menuName = InputViewRoutes.InputSourcesRoot + "Mouse")]
    public class MouseInputFactory : InputSourceFactory
    {
        public override void Create(Controls controls, IServiceCollection services)
        {
            var gamePlay = controls.GamePlay;
            services.Register<MouseInput>()
                .WithParameter(gamePlay)
                .As<IMouseInput>()
                .AsSelfResolvable();
        }
    }
}