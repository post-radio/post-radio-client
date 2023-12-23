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

        public Vector2 Resolution => new(Screen.width, Screen.height);

        public void Quit()
        {
            Application.Quit();
        }
    }
}