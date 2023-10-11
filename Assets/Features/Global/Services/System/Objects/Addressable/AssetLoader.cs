using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Global.System.Objects.Addressable
{
    public class AssetLoader : IAssetLoader
    {
        public async UniTask<T> Load<T>(AssetReference reference) where T : MonoBehaviour
        {
            var result = await reference.LoadAssetAsync<T>().ToUniTask();
            
            return result;
        }

        public void Unload<T>(AssetReference reference) where T : MonoBehaviour
        {
            reference.ReleaseAsset();
        }
    }
}