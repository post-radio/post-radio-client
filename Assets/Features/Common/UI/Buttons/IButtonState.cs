namespace Common.UI.Buttons
{
    public interface IButtonState
    {
        void Construct(IButtonUtils utils);
        void Dispose();
    }
}