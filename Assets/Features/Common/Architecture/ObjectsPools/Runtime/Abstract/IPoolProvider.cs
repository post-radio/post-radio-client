using UnityEngine;

namespace Common.Architecture.ObjectsPools.Runtime.Abstract
{
    public interface IPoolProvider
    {
        IObjectProvider<T> GetPool<T>(T prefab) where T : MonoBehaviour;
        IObjectProvider<T> GetPool<T>(string key);
    }
}