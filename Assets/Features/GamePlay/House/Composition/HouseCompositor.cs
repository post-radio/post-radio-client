using System.Collections.Generic;
using GamePlay.House.Cells.Root;
using UnityEngine;

namespace GamePlay.House.Composition
{
    [DisallowMultipleComponent]
    public class HouseCompositor : MonoBehaviour, IHouseCompositor
    {
        [SerializeField] private Transform _root;

        public void OrderCells(IReadOnlyList<ICell> cells)
        {
            foreach (var cell in cells)
            {
                cell.Transform.parent = _root;
            }
        }
    }
}