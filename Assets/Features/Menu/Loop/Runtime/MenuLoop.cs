using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using GamePlay.Services.LevelCameras.Runtime;
using Global.UI.Nova.InputManagers.Abstract;
using Menu.StateMachine.Definitions;
using Menu.StateMachine.Runtime;

namespace Menu.Loop.Runtime
{
    public class MenuLoop : IScopeLoadListener, IScopeDisableListener
    {
        public MenuLoop(
            IStateMachine stateMachine,
            ITabDefinition mainDefinition,
            IUIInputManager iuiInputManager,
            ILevelCamera levelCamera)
        {
            _stateMachine = stateMachine;
            _mainDefinition = mainDefinition;
            _iuiInputManager = iuiInputManager;
            _levelCamera = levelCamera;
        }

        private readonly IStateMachine _stateMachine;
        private readonly ITabDefinition _mainDefinition;
        private readonly IUIInputManager _iuiInputManager;
        private readonly ILevelCamera _levelCamera;

        public void OnLoaded()
        {
            _iuiInputManager.SetCamera(_levelCamera.Camera);
            _stateMachine.Select(_mainDefinition).Forget();
        }

        public void OnDisabled()
        {
            _iuiInputManager.RemoveCamera(_levelCamera.Camera);
        }
    }
}