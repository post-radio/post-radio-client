using UnityEngine;

namespace Common.Architecture.ObjectsPools.Runtime.Abstract
{
    public interface IObjectFactory<T>
    {
        T Create(Vector2 position, float angle = 0f);
    }
}