using UnityEngine;

namespace Global.System.ApplicationProxies.Runtime
{
    public interface IScreen
    {
        ScreenMode ScreenMode { get; }
        Vector2 Resolution { get; }
    }
}