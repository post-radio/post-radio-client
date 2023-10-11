using Common.Architecture.DiContainer.Abstract;
using UnityEngine;

namespace GamePlay.Common.SceneBootstrappers.Runtime
{
    public abstract class SceneComponentRegister : MonoBehaviour
    {
        public abstract void Register(IServiceCollection builder);
    }
}