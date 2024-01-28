using Common.Architecture.Container.Abstract;
using Global.Inputs.View.Common;
using Global.Inputs.View.Runtime.Sources;
using UnityEngine;

namespace Global.Inputs.View.Implementations.Movement
{
    [CreateAssetMenu(
        fileName = InputViewRoutes.InputSourcePrefix + "Movement",
        menuName = InputViewRoutes.InputSourcesRoot + "Movement")]
    public class MovementInputFactory : InputSourceFactory
    {
        public override void Create(Controls controls, IServiceCollection services)
        {
            var gamePlay = controls.GamePlay;
            // services.Register<MouseInput>()
            //     .WithParameter(gamePlay)
            //     .As<IMouseInput>()
            //     .AsSelfResolvable();
        }
    }
}