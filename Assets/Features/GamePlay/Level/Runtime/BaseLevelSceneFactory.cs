using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GamePlay.Level.Runtime
{
    public abstract class BaseLevelSceneFactory : ScriptableObject, IServiceFactory
    {
        public abstract UniTask Create(IServiceCollection builder, IScopeUtils utils);
    }
}