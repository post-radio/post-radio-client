using System.Collections.Generic;
using System.Linq;
using GamePlay.House.Cells.Root;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.House.Composition
{
    public class HouseCompositor : MonoBehaviour, IHouseCompositor
    {
        [SerializeField] private float _cellSize = 1f;
        [SerializeField] private Transform _root;

        [SerializeField] [Min(0)] private int _rowCapacity;

        private readonly List<Transform> _cells = new();
        
        public void AddCell(Transform cell)
        {
            _cells.Add(cell);
            
            OrderCells();
        }

        private void OrderCells()
        {
            var rowsCount = _cells.Count / _rowCapacity;
            var xOffset = (_rowCapacity * _cellSize) / -2f;
            var yOffset = _root.position.y;

            for (var y = 0; y <= rowsCount; y++)
            {
                for (var x = 0; x < _rowCapacity; x++)
                {
                    var cellIndex = y * _rowCapacity + x;
                    
                    if (cellIndex >= _cells.Count)
                        break;

                    var xPosition = _cellSize * x + xOffset;
                    var yPosition = _cellSize * y + yOffset;

                    var position = new Vector2(xPosition, yPosition);
                    var cell = _cells[cellIndex];

                    cell.position = position;
                }
            }
        }

        [Button("Order")]
        private void TestOrder()
        {
            var cells = FindObjectsByType<CellRoot>(FindObjectsSortMode.None).Select(cell => cell.transform).ToList();
            
            _cells.Clear();
            _cells.AddRange(cells);
            
            OrderCells();
        }
    }
}