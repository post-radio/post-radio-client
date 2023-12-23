using System.Collections.Generic;
using Common.Tools.ObjectsPools.Runtime.Abstract;
using UnityEngine;

namespace Common.Tools.ObjectsPools.Runtime
{
    public class ObjectsRegistry<T> where T : IPoolObject
    {
        private readonly List<IPoolObject> _active = new();
        private readonly List<IPoolObject> _inactive = new();
        private readonly Dictionary<IPoolObject, T> _values = new();

        public bool ContainsInactive()
        {
            return _inactive.Count != 0;
        }

        public void OnActiveCreated(T poolObject)
        {
            _active.Add(poolObject);

            _values.Add(poolObject, poolObject);
        }

        public void OnInactiveCreated(T poolObject)
        {
            _inactive.Add(poolObject);

            _values.Add(poolObject, poolObject);
        }

        public T GetInactive()
        {
            var poolObject = _inactive[0];

            _inactive.RemoveAt(0);
            _active.Add(poolObject);

            poolObject.GameObject.SetActive(true);

            return _values[poolObject];
        }

        public void OnReturned(IPoolObject poolObject)
        {
            _inactive.Add(poolObject);
            _active.Remove(poolObject);
        }

        public void DestroyAll()
        {
            foreach (var poolObject in _active)
            {
                poolObject.OnReturned();
                Object.Destroy(poolObject.GameObject);
            }

            foreach (var poolObject in _inactive)
            {
                poolObject.OnReturned();
                Object.Destroy(poolObject.GameObject);
            }

            _active.Clear();
            _inactive.Clear();
        }
    }
}