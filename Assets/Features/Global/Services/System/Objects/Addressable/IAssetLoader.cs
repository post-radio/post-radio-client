using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Global.System.Objects.Addressable
{
    public interface IAssetLoader
    {
        UniTask<T> Load<T>(AssetReference reference) where T : MonoBehaviour;
        void Unload<T>(AssetReference reference) where T : MonoBehaviour;
    }
}