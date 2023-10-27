using GamePlay.House.Cells.Root;
using UnityEngine;

namespace GamePlay.House.Cells.Factory
{
    public class CellFactory : ICellFactory
    {
        public CellFactory(CellFactoryConfig config)
        {
            _config = config;
        }

        private readonly CellFactoryConfig _config;

        private int _counter;
        
        public ICell Create()
        {
            var cell = Object.Instantiate(_config.Prefab) as ICell;

            cell.SetId(_counter);
            
            _counter++;
            
            return cell;
        }
    }
}