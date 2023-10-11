using UnityEngine.ResourceManagement.ResourceProviders;

namespace Internal.Services.Scenes.Abstract
{
    public interface ISceneInstanceProvider
    {
        SceneInstance SceneInstance { get; }
    }
}