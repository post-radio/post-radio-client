using Common.Tools.ObjectsPools.Runtime.Abstract;
using UnityEngine;

namespace GamePlay.Services.VfxPools.Runtime
{
    public class VfxObjectFactory<T> : IObjectFactory<T> where T : MonoBehaviour
    {
        public VfxObjectFactory(
            T prefab,
            Transform parent)
        {
            _prefab = prefab;
            _parent = parent;
        }

        private readonly Transform _parent;
        private readonly T _prefab;

        public T Create(Vector2 position, float angle = 0)
        {
            var rotation = Quaternion.Euler(0f, 0f, angle);
            var vfx = Object.Instantiate(_prefab, position, rotation, _parent);

            return vfx;
        }
    }
}