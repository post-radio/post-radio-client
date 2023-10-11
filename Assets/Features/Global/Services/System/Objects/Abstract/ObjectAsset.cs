using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Global.System.Objects.Abstract
{
    public abstract class ObjectAsset<T> : ScriptableObject, IObjectAsset<T> where T : Object
    {
        [SerializeField] private GameObject _object;
        [SerializeField] private AssetReference _reference;

        public GameObject Object => _object;
        public AssetReference Reference => _reference;
    }
}