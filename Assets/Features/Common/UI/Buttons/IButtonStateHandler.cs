namespace Common.UI.Buttons
{
    public interface IButtonStateHandler
    {
        void Lock(IButtonState current);
        bool IsLocked(IButtonState state);
    }
}