using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Config.Runtime;
using Global.GameLoops.Common;
using Menu.Config.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.GameLoops.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = GameLoopRouter.ServiceName,
        menuName = GameLoopRouter.ServicePath)]
    public class GameLoopFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private MenuScopeConfig _menuScope;
        [SerializeField] private LevelScopeConfig _levelScope;

        public virtual async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<GameLoop>()
                .WithParameter(_levelScope)
                .WithParameter(_menuScope)
                .WithParameter(utils.Data.Scope)
                .AsSelfResolvable()
                .AsCallbackListener();
        }
    }
}