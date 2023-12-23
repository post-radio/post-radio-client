using GamePlay.Common.Paths;

namespace GamePlay.House.Common.Paths
{
    public class HouseRoutes
    {
        private const string _cellsRoot = GamePlayAssetsPaths.Root + "House/Cells";
        private const string _houseRoot = GamePlayAssetsPaths.Root + "House/";

        public const string HouseConfigName = "HouseConfig";
        public const string HouseConfigPath = GamePlayAssetsPaths.Root + "House/SetupConfig";

        public const string CellFactoryConfigName = "CellFactoryConfig";
        public const string CellFactoryConfigPath = _cellsRoot + "Factory/Config";

        public const string CellFactoryName = GamePlayAssetsPrefixes.Service + "CellFactory";
        public const string CellFactoryPath = _cellsRoot + "Factory/Service";

        public const string HouseSetupName = GamePlayAssetsPrefixes.Service + "HouseSetup";
        public const string HouseSetupPath = _houseRoot + "Setup";
    }
}