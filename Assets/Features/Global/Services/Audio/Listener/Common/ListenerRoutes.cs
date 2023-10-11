using Global.Common;

namespace Global.Audio.Listener.Common
{
    public class ListenerRoutes
    {
        private const string _paths = GlobalAssetsPaths.Root + "Audio/Listener/";

        public const string ServicePath = _paths + "Service";
        public const string ServiceName = GlobalAssetsPrefixes.Service + "AudioListener";
    }
}