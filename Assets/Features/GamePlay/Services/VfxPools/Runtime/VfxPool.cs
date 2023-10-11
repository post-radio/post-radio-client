using Common.Architecture.ObjectsPools.Runtime.Abstract;
using UnityEngine;

namespace GamePlay.Services.VfxPools.Runtime
{
    public class VfxPool : IVfxPool
    {
        public VfxPool(IPoolProvider pools)
        {
            _pools = pools;
        }

        private readonly IPoolProvider _pools;

        public IObjectProvider<T> GetPool<T>(T prefab) where T : MonoBehaviour
        {
            return _pools.GetPool(prefab);
        }

        public IObjectProvider<T> GetPool<T>(string key)
        {
            return _pools.GetPool<T>(key);
        }
    }
}