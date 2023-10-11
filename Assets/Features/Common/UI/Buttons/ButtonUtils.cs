namespace Common.UI.Buttons
{
    public class ButtonUtils : IButtonUtils
    {
        public ButtonUtils(ITriggerReceiver triggerReceiver, IButtonStateHandler stateHandler)
        {
            _triggerReceiver = triggerReceiver;
            _stateHandler = stateHandler;
        }
        
        private readonly ITriggerReceiver _triggerReceiver;
        private readonly IButtonStateHandler _stateHandler;

        public ITriggerReceiver TriggerReceiver => _triggerReceiver;
        public IButtonStateHandler StateHandler => _stateHandler;
    }
}