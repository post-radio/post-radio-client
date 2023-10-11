using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Global.System.Objects.Addressable
{
    public class InstanceHandle<T> where T : MonoBehaviour
    {
        public InstanceHandle(AssetReference reference, T value)
        {
            _reference = reference;
            _value = value;
            _instances = new List<T>();
        }

        private readonly AssetReference _reference;
        private readonly List<T> _instances;
        private readonly T _value;

        public IReadOnlyList<T> Instances => _instances;
        
        public void OnCreated(T instance)
        {
            _instances.Add(instance);
        }

        public void OnDestroyed(T instance)
        {
            _instances.Remove(instance);
        }
    }
}