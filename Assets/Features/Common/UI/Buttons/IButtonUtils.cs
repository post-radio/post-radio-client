namespace Common.UI.Buttons
{
    public interface IButtonUtils
    {
        ITriggerReceiver TriggerReceiver { get; }
        IButtonStateHandler StateHandler { get; }
    }
}