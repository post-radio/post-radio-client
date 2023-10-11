using UnityEngine;

namespace Global.System.ApplicationProxies.Runtime
{
    public class ApplicationProxy : IApplicationFlow, IScreen
    {
        public ScreenMode ScreenMode
        {
            get
            {
                if (Screen.height > Screen.width)
                    return ScreenMode.Vertical;

                return ScreenMode.Horizontal;
            }
        }
        
        public void Quit()
        {
            Application.Quit();
        }
    }
}