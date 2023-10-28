﻿using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Global.UI.EventSystems.Common;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Global.UI.EventSystems.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EventSystemRoutes.ServiceName, menuName = EventSystemRoutes.ServicePath)]
    public class EventSystemFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private EventSystem _prefab;
        
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var eventSystem = Instantiate(_prefab);
            eventSystem.name = "EventSystem";

            utils.Binder.MoveToModules(eventSystem);
        }
    }
}