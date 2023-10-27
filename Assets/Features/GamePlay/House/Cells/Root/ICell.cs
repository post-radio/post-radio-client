using UnityEngine;

namespace GamePlay.House.Cells.Root
{
    public interface ICell
    {
        int Id { get; }
        Transform Transform { get; }
        Transform CameraPoint { get; }

        void SetId(int id);
        void OnTaken();
        void OnFreed();
    }
}