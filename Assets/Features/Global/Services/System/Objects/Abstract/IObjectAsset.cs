using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Global.System.Objects.Abstract
{
    public interface IObjectAsset<T>
    {
        GameObject Object { get; }
        AssetReference Reference { get; }
    }
}