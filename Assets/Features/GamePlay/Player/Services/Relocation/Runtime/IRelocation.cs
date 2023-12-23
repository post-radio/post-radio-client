using Cysharp.Threading.Tasks;
using GamePlay.House.Cells.Root;

namespace GamePlay.Player.Services.Relocation.Runtime
{
    public interface IRelocation
    {
        ICell GetCell(int id);
        UniTask<ICell> GetRandomCell();
        UniTask<bool> TryGetTargetCell(ICell target);
        void OnCellFreed(ICell cell);
    }
}