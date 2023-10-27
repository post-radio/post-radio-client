using GamePlay.House.Cells.Root;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Visual.View
{
    public interface IPlayerView
    {
        GameObject Object { get; }

        void SnapToCell(ICell cell);
    }
}