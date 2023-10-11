using UnityEngine.SceneManagement;

namespace Internal.Services.Scenes.Abstract
{
    public interface ISceneLoadResult
    {
        Scene Scene { get; }
    }
}