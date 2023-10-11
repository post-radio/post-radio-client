using Global.Common;

namespace Common.UniversalAnimators.Updaters.Common
{
    public class AnimatorsUpdaterRoutes
    {
        private const string _paths = GlobalAssetsPaths.Root + "System/Updater/Animators/";

        public const string ServicePath = _paths + "Service";
        public const string ServiceName = GlobalAssetsPrefixes.Service + "AnimatorsUpdater";
    }
}