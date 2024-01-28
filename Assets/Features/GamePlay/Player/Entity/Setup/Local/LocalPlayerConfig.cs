using System.Collections.Generic;
using Common.Architecture.Entities.Runtime;
using Common.Architecture.Entities.Runtime.Callbacks;
using GamePlay.Player.Entity.Components.Animators.Runtime;
using GamePlay.Player.Entity.Components.Identity.Local;
using GamePlay.Player.Entity.Components.Location.Local;
using GamePlay.Player.Entity.Components.PropertiesBinders.Runtime;
using GamePlay.Player.Entity.Components.Root.Local;
using GamePlay.Player.Entity.Components.Visual.Local;
using GamePlay.Player.Entity.Setup.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Setup.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = PlayerSetupRoutes.LocalName, menuName = PlayerSetupRoutes.LocalPath)]
    public class LocalPlayerConfig : ScriptableObject, IEntityConfig
    {
        [SerializeField] private LocalPlayerViewFactory _prefab;
        
        [SerializeField] private LocalIdentityFactory _identity;
        [SerializeField] private LocalLocationFactory _location;
        [SerializeField] private LocalVisualFactory _visual;
        [SerializeField] private LocalRootFactory _root;
        [SerializeField] private PropertyBinderFactory _propertyBinder;
        [SerializeField] private AnimatorFactory _animator;
        
        public EntitySetupView Prefab => _prefab;
        public IReadOnlyList<IComponentFactory> Components => GetComponents();
        public IReadOnlyList<ICallbacksFactory> Callbacks => new ICallbacksFactory[] { new DefaultCallbacksFactory() };

        private IReadOnlyList<IComponentFactory> GetComponents()
        {
            return new IComponentFactory[]
            {
                _identity,
                _location,
                _visual,
                _root,
                _propertyBinder,
                _animator
            };
        }
    }
}