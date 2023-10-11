using Common.Architecture.DiContainer.Abstract;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer.Unity;

namespace GamePlay.Common.SceneBootstrappers.Runtime
{
    public abstract class SceneComponentBuilder : MonoBehaviour
    {
        public abstract UniTask Build(LifetimeScope parent, ICallbackRegister callbacks);
    }
}