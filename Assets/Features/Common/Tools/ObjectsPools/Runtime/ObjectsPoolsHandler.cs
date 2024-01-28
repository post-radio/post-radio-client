using System.Collections.Generic;
using Common.Architecture.Container.Abstract;
using Common.Tools.ObjectsPools.Runtime.Abstract;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Common.Tools.ObjectsPools.Runtime
{
    public class ObjectsPoolsHandler : MonoBehaviour, IPoolProvider
    {
        [SerializeField] private PoolEntryAsset[] _entries;

        private readonly Dictionary<object, IObjectsPool> _pools = new();

        public void CreatePools(IServiceCollection builder, Scene targetScene)
        {
            foreach (var entry in _entries)
            {
                var parent = CreateParent(entry.Name, targetScene);
                var provider = entry.Create(builder, parent);
                _pools.Add(entry.Key, provider);
            }

            foreach (var objectHandler in _pools)
                objectHandler.Value.Preload();
        }

        public IObjectProvider<T> GetPool<T>(T prefab) where T : MonoBehaviour
        {
            if (_pools.ContainsKey(prefab.name) == false)
            {
                Debug.LogError($"No pool with key: {prefab.name} found");
                return null;
            }

            var pool = _pools[prefab.name];
            var provider = pool.GetProvider<T>();

            return provider;
        }

        public IObjectProvider<T> GetPool<T>(string key)
        {
            if (_pools.ContainsKey(key) == false)
            {
                Debug.LogError($"No pool with key: {key} found");
                return null;
            }

            var pool = _pools[key];
            var provider = pool.GetProvider<T>();

            return provider;
        }

        private Transform CreateParent(string assetName, Scene targetScene)
        {
            var root = new GameObject($"{assetName} objects")
            {
                transform =
                {
                    position = Vector3.zero
                }
            };

            SceneManager.MoveGameObjectToScene(root, targetScene);

            return root.transform;
        }
    }
}