using Common.Architecture.ScopeLoaders.Runtime.Callbacks;

namespace GamePlay.UI.Runtime
{
    public class LevelUiController : ILevelUiController, IScopeSwitchListener
    {
        public LevelUiController(ILevelUiView view)
        {
            _view = view;
        }

        private readonly ILevelUiView _view;

        public void OnEnabled()
        {
        }

        public void OnDisabled()
        {
        }
    }
}