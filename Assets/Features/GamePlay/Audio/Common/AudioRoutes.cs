using GamePlay.Common.Paths;

namespace GamePlay.Audio.Common
{
    public class AudioRoutes
    {
        private const string Path = GamePlayAssetsPaths.Root + "Audio/";
        private const string Name = GamePlayAssetsPrefixes.Service + "Audio_";

        public const string ComposePath = Path + "Compose";
        public const string ComposeName = Name + "Compose";
        
        public const string ControllerPath = Path + "Controller";
        public const string ControllerName = Name + "Controller";

        public const string SyncPath = Path + "Sync";
        public const string SyncName = Name + "Sync";

        public const string PlayerPath = Path + "Player";
        public const string PlayerName = Name + "Player";

        public const string VotingPath = Path + "Voting";
        public const string VotingName = Name + "Voting";

        public const string BackendPath = Path + "Backend";
        public const string BackendName = Name + "Backend";
        
        public const string BackendRoutesPath = Path + "BackendRoutes";
        public const string BackendRoutesName = Name + "BackendRoutes";
    }
}