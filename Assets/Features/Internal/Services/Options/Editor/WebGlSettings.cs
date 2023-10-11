using UnityEditor;

namespace Internal.Services.Options.Editor
{
    public class WebGlSettings
    {
        public WebGlSettings()
        {
            PlayerSettings.WebGL.emscriptenArgs = "-Wl,--trace-symbol=sendfile";
        }
    }
}