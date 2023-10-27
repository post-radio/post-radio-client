using Cysharp.Threading.Tasks;
using GamePlay.House.Cells.Root;

namespace GamePlay.Player.Entity.Components.Location.Common
{
    public interface IPlayerLocation
    {
        bool HasLocation { get; }
        ICell Cell { get; }

        UniTask Relocate(ICell cell);
    }
}