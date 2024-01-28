using Global.Common;

namespace Global.UI.Overlays.Common
{
    public static class OverlayRouter
    {
        private const string Paths = GlobalAssetsPaths.Root + "UI/Overlay/";

        public const string ServicePath = Paths + "Service";
        public const string ServiceName = GlobalAssetsPrefixes.Service + "Overlay";

        public const string LogsPath = Paths + "Logger";
        public const string LogsName = GlobalAssetsPrefixes.Logs + "Overlay";
    }
}