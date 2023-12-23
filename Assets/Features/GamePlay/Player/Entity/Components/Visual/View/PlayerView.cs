using GamePlay.House.Cells.Root;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Visual.View
{
    [DisallowMultipleComponent]
    public class PlayerView : MonoBehaviour, IPlayerView
    {
        public GameObject Object => gameObject;
        
        public void SnapToCell(ICell cell)
        {
            transform.parent = cell.CameraPoint;
            transform.localPosition = Vector3.zero;
        }
    }
}