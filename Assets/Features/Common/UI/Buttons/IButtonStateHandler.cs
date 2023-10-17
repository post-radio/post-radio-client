namespace Common.UI.Buttons
{
    public interface IButtonStateHandler
    {
        void Lock(ButtonState current);
        bool IsLocked(ButtonState state);
    }
}