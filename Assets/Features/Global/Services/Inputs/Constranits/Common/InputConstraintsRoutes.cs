using Global.Common;
using Global.Inputs.Common;

namespace Global.Inputs.Constranits.Common
{
    public class InputConstraintsRoutes
    {
        private const string Paths = InputRoutes.Root + "Constraints/";

        public const string ServicePath = Paths + "Service";
        public const string ServiceName = GlobalAssetsPrefixes.Service + "InputConstraints";
    }
}