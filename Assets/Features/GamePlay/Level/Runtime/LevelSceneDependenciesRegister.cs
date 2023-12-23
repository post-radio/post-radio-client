using Common.Architecture.DiContainer.Abstract;
using GamePlay.Common.SceneBootstrappers.Runtime;
using UnityEngine;

namespace GamePlay.Level.Runtime
{
    [DisallowMultipleComponent]
    public class LevelSceneDependenciesRegister : SceneComponentRegister
    {
        public override void Register(IServiceCollection builder)
        {
        }
    }
}