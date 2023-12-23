using GamePlay.Common.Paths;

namespace GamePlay.Chat.Common
{
    public class ChatRoutes
    {
        private const string _path = GamePlayAssetsPaths.Root + "Chat/";
        private const string _name = GamePlayAssetsPrefixes.Service + "Chat_";

        public const string ComposePath = _path + "Compose";
        public const string ComposeName = _name + "Compose";
        
        public const string ControllerPath = _path + "Controller";
        public const string ControllerName = _name + "Controller";

        public const string InGamePath = _path + "InGame";
        public const string InGameName = _name + "InGame";

        public const string UIPath = _path + "UI";
        public const string UIName = _name + "UI";
    }
}