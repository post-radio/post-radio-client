using System;

namespace Menu.Common.Pages
{
    public interface IPagesSwitchInvoker
    {
        event Action PreviousRequested;
        event Action NextRequested;

        void Enable();
        void Disable();

        void EnablePrevious();
        void DisablePrevious();
        
        void EnableNext();
        void DisableNext();
    }
}