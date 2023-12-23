using UnityEngine;

namespace Common.Tools.ObjectsPools.Runtime.Abstract
{
    public interface IObjectFactory<T>
    {
        T Create(Vector2 position, float angle = 0f);
    }
}