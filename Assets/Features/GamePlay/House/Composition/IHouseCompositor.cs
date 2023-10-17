using UnityEngine;

namespace GamePlay.House.Composition
{
    public interface IHouseCompositor
    {
        void AddCell(Transform cell);
    }
}