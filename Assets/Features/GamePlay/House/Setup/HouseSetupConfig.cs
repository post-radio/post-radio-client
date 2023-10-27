using GamePlay.House.Common.Paths;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.House.Setup
{
    [InlineEditor]
    [CreateAssetMenu(fileName = HouseRoutes.HouseConfigName, menuName = HouseRoutes.HouseConfigPath)]
    public class HouseSetupConfig : ScriptableObject
    {
        [SerializeField] private int _rowsCount;
        [SerializeField] private int _columnsCount;

        public int RowsCount => _rowsCount;
        public int ColumnsCount => _columnsCount;
    }
}