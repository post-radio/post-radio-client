using System.Collections.Generic;
using System.Linq;
using GamePlay.House.Cells.Root;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.House.Composition
{
    [DisallowMultipleComponent]
    public class HouseCompositor : MonoBehaviour, IHouseCompositor
    {
        [SerializeField] private float _cellSize = 1f;
        [SerializeField] private Transform _root;

        [SerializeField] [Min(0)] private int _debugRawCapacity;

        public void OrderCells(IReadOnlyList<ICell> cells, int rowCapacity)
        {
            var rowsCount = cells.Count / rowCapacity;
            var xOffset = (rowCapacity * _cellSize) / -2f;
            var yOffset = _root.position.y;

            for (var y = 0; y <= rowsCount; y++)
            {
                for (var x = 0; x < rowCapacity; x++)
                {
                    var cellIndex = y * rowCapacity + x;
                    
                    if (cellIndex >= cells.Count)
                        break;

                    var xPosition = _cellSize * x + xOffset;
                    var yPosition = _cellSize * y + yOffset;

                    var position = new Vector2(xPosition, yPosition);
                    var cell = cells[cellIndex].Transform;

                    cell.parent = _root;
                    cell.position = position;
                }
            }
        }

        [Button("Order")]
        private void TestOrder()
        {
            var cells = FindObjectsByType<Cell>(FindObjectsSortMode.None).ToList();
            
            OrderCells(cells, _debugRawCapacity);
        }
    }
}