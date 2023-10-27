using System.Collections.Generic;
using GamePlay.House.Cells.Root;

namespace GamePlay.House.Root
{
    public class HouseCells : IHouseCells
    {
        private readonly List<ICell> _list = new();
        private readonly Dictionary<int, ICell> _dictionary = new();

        public IReadOnlyList<ICell> List => _list;
        public IReadOnlyDictionary<int, ICell> Dictionary => _dictionary;

        public void Construct(IReadOnlyDictionary<int, ICell> cells)
        {
            foreach (var (id, cell) in cells)
            {
                _dictionary.Add(id, cell);
                _list.Add(cell);
            }
        }

        public ICell Get(int id)
        {
            return _dictionary[id];
        }
    }
}