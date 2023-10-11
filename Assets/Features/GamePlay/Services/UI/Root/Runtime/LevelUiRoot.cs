using Global.UI.UiStateMachines.Runtime;

namespace GamePlay.Services.UI.Root.Runtime
{
    public class LevelUiRoot : ILevelUiRoot
    {
        public LevelUiRoot(
            IUiStateMachine uiStateMachine,
            UiConstraints constraints)
        {
            _uiStateMachine = uiStateMachine;
            Constraints = constraints;
        }

        private readonly IUiStateMachine _uiStateMachine;

        public UiConstraints Constraints { get; }
        public string Name => "Root";

        public void Open()
        {
            _uiStateMachine.EnterAsSingle(this);
        }

        public void Recover()
        {
        }

        public void Exit()
        {
        }
    }
}