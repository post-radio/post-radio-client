using System.Collections.Generic;
using Common.Architecture.EntityCreators.Runtime;
using Common.Architecture.EntityCreators.Runtime.Callbacks;
using GamePlay.Player.Entity.Components.Animators.Runtime;
using GamePlay.Player.Entity.Components.Identity.Remote;
using GamePlay.Player.Entity.Components.Location.Remote;
using GamePlay.Player.Entity.Components.PropertiesBinders.Runtime;
using GamePlay.Player.Entity.Components.Root.Remote;
using GamePlay.Player.Entity.Components.Visual.Remote;
using GamePlay.Player.Entity.Setup.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Setup.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = PlayerSetupRoutes.RemoteName, menuName = PlayerSetupRoutes.RemotePath)]
    public class RemotePlayerConfig : ScriptableObject, IEntityConfig
    {
        [SerializeField] private RemotePlayerViewFactory _prefab;
        
        [SerializeField] private RemoteIdentityFactory _identity;
        [SerializeField] private RemoteLocationFactory _location;
        [SerializeField] private RemoteVisualFactory _visual;
        [SerializeField] private RemoteRootFactory _root;
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