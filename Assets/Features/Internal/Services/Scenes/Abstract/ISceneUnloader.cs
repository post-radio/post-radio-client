using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace Internal.Services.Scenes.Abstract
{
    public interface ISceneUnloader
    {
        UniTask Unload(ISceneLoadResult result);

        UniTask Unload(IReadOnlyList<ISceneLoadResult> results);
    }
}