using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using GamePlay.House.Cells.Factory;
using GamePlay.House.Cells.Root;
using GamePlay.House.Composition;
using GamePlay.House.Root;

namespace GamePlay.House.Setup
{
    public class HouseSetup : IHouseSetup
    {
        public HouseSetup(
            IHouseCompositor houseCompositor,
            ICellFactory cellFactory,
            IHouseCells cells,
            HouseSetupConfig config)
        {
            _houseCompositor = houseCompositor;
            _cellFactory = cellFactory;
            _cells = cells;
            _config = config;
        }
        
        private readonly IHouseCompositor _houseCompositor;
        private readonly ICellFactory _cellFactory;
        private readonly IHouseCells _cells;
        private readonly HouseSetupConfig _config;

        public async UniTask Setup()
        {
            var cellsAmount = _config.ColumnsCount * _config.RowsCount;
            var cells = new Dictionary<int, ICell>();

            for (var i = 0; i < cellsAmount; i++)
            {
                var cell = _cellFactory.Create();
                cells.Add(cell.Id, cell);
            }

            _houseCompositor.OrderCells(cells.Values.ToList(), _config.RowsCount);

            _cells.Construct(cells);
        }
    }
}