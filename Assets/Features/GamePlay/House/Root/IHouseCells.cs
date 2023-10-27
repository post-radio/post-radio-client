using System.Collections.Generic;
using GamePlay.House.Cells.Root;

namespace GamePlay.House.Root
{
    public interface IHouseCells
    {
        IReadOnlyList<ICell> List { get; }
        IReadOnlyDictionary<int, ICell> Dictionary { get; }
        void Construct(IReadOnlyDictionary<int, ICell> cells);
        ICell Get(int id);
    }
}