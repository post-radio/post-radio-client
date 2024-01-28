using Global.Common;

namespace Global.UI.Nova.Common
{
    public class NovaRoutes
    {
        private const string Paths = GlobalAssetsPaths.Root + "Nova/";
        
        public const string ComposeName = GlobalAssetsPrefixes.Service + "Nova_Compose";
        public const string ComposePath = Paths + "Compose";
        
        public const string LogsName = GlobalAssetsPrefixes.Logs + "Nova_InputManager";
        public const string LogsPath = Paths + "LogSettings";
        
        public const string ButtonColorsName = "ButtonColors_";
        public const string ButtonColorsPath = Paths + "Colors/Button";
    }
}