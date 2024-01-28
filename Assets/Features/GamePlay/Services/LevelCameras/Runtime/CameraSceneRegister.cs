using Common.Architecture.Container.Abstract;
using GamePlay.Common.SceneBootstrappers.Runtime;
using UnityEngine;

namespace GamePlay.Services.LevelCameras.Runtime
{
    [DisallowMultipleComponent]
    public class CameraSceneRegister : SceneComponentRegister
    {
        [SerializeField] private CameraBorders _borders;
        
        public override void Register(IServiceCollection builder)
        {
            builder.RegisterComponent(_borders)
                .As<ICameraBorders>();
        }
    }
}