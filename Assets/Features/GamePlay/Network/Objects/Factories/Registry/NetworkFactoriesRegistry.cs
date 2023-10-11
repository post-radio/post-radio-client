using System;
using System.Collections.Generic;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Global.Network.Objects.EntityListeners.Runtime;
using Global.Network.Objects.Factories.Abstract;
using Ragon.Client;

namespace GamePlay.Network.Objects.Factories.Registry
{
    public class NetworkFactoriesRegistry : INetworkFactoriesRegistry, IScopeSwitchListener
    {
        public NetworkFactoriesRegistry(IEntityListener entityListener)
        {
            _entityListener = entityListener;
        }

        private readonly IEntityListener _entityListener;
        private readonly Dictionary<int, IEntityFactory> _factories = new();

        private int _counter;
        
        public void OnEnabled()
        {
            _entityListener.EntityReceived += OnEntityReceived;
        }

        public void OnDisabled()
        {
            _entityListener.EntityReceived -= OnEntityReceived;
        }

        public void Register(IEntityFactory factory)
        {
            _counter++;

            factory.AssignId(_counter);

            _factories.Add(factory.Id, factory);
        }

        public void Unregister(IEntityFactory factory)
        {
            _factories.Remove(factory.Id);
        }
        
        private void OnEntityReceived(EntityPrefabId id, RagonEntity entity)
        {
            var factory = GetFactory(id.FactoryId);
            
            factory.CreateRemote(id.ObjectId, entity).Forget();
        }
        
        private IEntityFactory GetFactory(int id)
        {
            if (_factories.ContainsKey(id) == false)
                throw new NullReferenceException($"No factory with id: {id} found");

            return _factories[id];
        }
    }
}