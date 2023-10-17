namespace Common.UI.Buttons
{
    public class ButtonStateHandler : IButtonStateHandler
    {
        private ButtonState _current;
        
        public void Lock(ButtonState current)
        {
            _current = current;
        }

        public bool IsLocked(ButtonState state)
        {
            return state == _current;
        }
    }
}