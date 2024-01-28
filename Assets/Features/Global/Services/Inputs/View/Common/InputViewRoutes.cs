using Global.Common;
using Global.Inputs.Common;

namespace Global.Inputs.View.Common
{
    public class InputViewRoutes
    {
        private const string Paths = InputRoutes.Root + "View/";

        public const string ServicePath = Paths + "Service";
        public const string ServiceName = GlobalAssetsPrefixes.Service + "InputView";

        public const string LogsPath = Paths + "Logger";
        public const string LogsName = GlobalAssetsPrefixes.Logs + "InputView";

        public const string InputSourcePrefix = "InputSource_";
        public const string InputSourcesRoot = Paths + "Sources/";
    }
}