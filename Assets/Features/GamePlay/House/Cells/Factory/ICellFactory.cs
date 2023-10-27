using GamePlay.House.Cells.Root;

namespace GamePlay.House.Cells.Factory
{
    public interface ICellFactory
    {
        ICell Create();
    }
}