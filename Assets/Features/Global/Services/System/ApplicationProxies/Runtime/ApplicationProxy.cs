using Global.System.ApplicationProxies.Logs;
using UnityEngine;

namespace Global.System.ApplicationProxies.Runtime
{
    public class ApplicationProxy : IApplicationFlow, IScreen
    {
        public ApplicationProxy(ApplicationProxyLogger logger)
        {
            _logger = logger;
        }

        private readonly ApplicationProxyLogger _logger;

        public Vector2 Resolution => new(Screen.width, Screen.height);

        public ScreenMode ScreenMode => GetScreenMode();

        public void Quit()
        {
            _logger.OnQuit();
            Application.Quit();
        }

        private ScreenMode GetScreenMode()
        {
            if (Screen.height > Screen.width)
                return ScreenMode.Vertical;

            return ScreenMode.Horizontal;
        }
    }
}