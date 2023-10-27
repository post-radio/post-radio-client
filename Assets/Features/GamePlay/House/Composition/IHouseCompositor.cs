using System.Collections.Generic;
using GamePlay.House.Cells.Root;

namespace GamePlay.House.Composition
{
    public interface IHouseCompositor
    {
        void OrderCells(IReadOnlyList<ICell> cells, int rowCapacity);
    }
}