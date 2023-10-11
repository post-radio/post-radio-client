using UnityEngine;

namespace Common.Architecture.ObjectsPools.Runtime.Abstract
{
    public interface IObjectProvider<out T>
    {
        T Get(Vector2 position);
    }
}