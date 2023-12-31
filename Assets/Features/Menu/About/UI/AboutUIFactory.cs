﻿using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Menu.About.Common;
using Menu.StateMachine.Definitions;
using Menu.StateMachine.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.About.UI
{
    [InlineEditor]
    [CreateAssetMenu(fileName = AboutRoutes.ControllerName,
        menuName = AboutRoutes.ControllerPath)]
    public class AboutUIFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private TabDefinition _tabDefinition;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<AboutController>()
                .As<IAboutController>()
                .AsTab<AboutController>(_tabDefinition);
        }
    }
}