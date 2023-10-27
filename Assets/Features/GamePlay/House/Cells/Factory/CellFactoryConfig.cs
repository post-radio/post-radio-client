using GamePlay.House.Cells.Root;
using GamePlay.House.Common.Paths;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.House.Cells.Factory
{
    [InlineEditor]
    [CreateAssetMenu(fileName = HouseRoutes.CellFactoryConfigName, menuName = HouseRoutes.CellFactoryConfigPath)]
    public class CellFactoryConfig : ScriptableObject
    {
        [SerializeField] private Cell _prefab;

        public Cell Prefab => _prefab;
    }
}