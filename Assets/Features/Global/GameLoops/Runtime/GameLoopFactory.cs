﻿using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
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
        [SerializeField] private MenuConfig _menu;
        [SerializeField] private LevelConfig _level;

        public virtual async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<GameLoop>()
                .WithParameter(_level)
                .WithParameter(_menu)
                .WithParameter(utils.Data.Scope)
                .AsSelfResolvable()
                .AsCallbackListener();
        }
    }
}