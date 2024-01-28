using Common.Architecture.Scopes.Runtime.Callbacks;
using GamePlay.Services.LevelCameras.Runtime;

namespace GamePlay.UI.Runtime
{
    public class LevelUiController : ILevelUiController, IScopeAwakeListener
    {
        private readonly ILevelUiScheme _scheme;
        private readonly ILevelCamera _levelCamera;

        public LevelUiController(ILevelUiScheme scheme, ILevelCamera levelCamera)
        {
            _scheme = scheme;
            _levelCamera = levelCamera;
        }

        public void OnAwake()
        {
            _scheme.ScreenSpace.TargetCamera = _levelCamera.Camera;
        }
    }
}