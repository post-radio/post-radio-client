using Global.Audio.Common;
using Global.Common;

namespace Global.Audio.Player.Common
{
    public static class GlobalAudioPlayerRoutes
    {
        private const string Path = GlobalAudioAssetsPaths.Root + "Player";
        
        public const string ServicePath = Path + "Player/Service";
        public const string ServiceName = GlobalAssetsPrefixes.Service + "AudioPlayer";

        public const string StatePath = Path + "Player/State";
        public const string StateName = GlobalAssetsPrefixes.Service + "AudioState";
    }
}