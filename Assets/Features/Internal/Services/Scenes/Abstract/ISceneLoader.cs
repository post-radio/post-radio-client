using Cysharp.Threading.Tasks;
using Internal.Services.Scenes.Data;

namespace Internal.Services.Scenes.Abstract
{
    public interface ISceneLoader
    {
        UniTask<ISceneLoadResult> Load(ISceneAsset sceneAsset);
        UniTask<ISceneLoadTypedResult<T>> LoadTyped<T>(ISceneAsset sceneAsset);
    }
}