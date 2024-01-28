using Global.Common;

namespace Common.Tools.UniversalAnimators.Updaters.Common
{
    public class AnimatorsUpdaterRoutes
    {
        private const string Paths = GlobalAssetsPaths.Root + "System/Updater/Animators/";

        public const string ServicePath = Paths + "Service";
        public const string ServiceName = GlobalAssetsPrefixes.Service + "AnimatorsUpdater";
    }
}