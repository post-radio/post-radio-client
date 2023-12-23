using Common.Architecture.EntityCreators.Factory;
using Common.Architecture.EntityCreators.Runtime;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using GamePlay.Network.Objects.Factories.Registry;
using GamePlay.Network.Objects.Factories.Runtime;
using GamePlay.Player.Entity.Components.Root.Common;
using GamePlay.Player.Entity.Definition;
using GamePlay.Player.Entity.Setup.Local;
using GamePlay.Player.Entity.Setup.Remote;
using GamePlay.Player.Services.Lists.Runtime;
using Global.Network.Objects.Factories.Abstract;
using Ragon.Client;
using UnityEngine;
using VContainer.Unity;

namespace GamePlay.Player.Services.Factory.Runtime
{
    public class PlayerFactory : IPlayerFactory, IEntityFactory, IScopeSwitchListener
    {
        public PlayerFactory(
            IDynamicEntityFactory dynamicEntityFactory,
            INetworkFactoriesRegistry factoriesRegistry,
            IPlayersList playersList,
            IEntityCreatorFactory creatorFactory,
            LocalPlayerConfig localConfig,
            RemotePlayerConfig remoteConfig,
            LifetimeScope parentScope)
        {
            _dynamicEntityFactory = dynamicEntityFactory;
            _factoriesRegistry = factoriesRegistry;
            _playersList = playersList;
            _localCreator = creatorFactory.Create(localConfig, parentScope);
            _remoteCreator = creatorFactory.Create(remoteConfig, parentScope);
        }

        private readonly IDynamicEntityFactory _dynamicEntityFactory;
        private readonly INetworkFactoriesRegistry _factoriesRegistry;
        private readonly IPlayersList _playersList;

        private readonly IEntityCreator _localCreator;
        private readonly IEntityCreator _remoteCreator;

        private ushort _id;

        public ushort Id => _id;

        public void OnEnabled()
        {
            _factoriesRegistry.Register(this);
        }

        public void OnDisabled()
        {
            _factoriesRegistry.Unregister(this);
        }

        public async UniTask<INetworkPlayer> CreateLocal()
        {
            var entity = _dynamicEntityFactory.Create(_id);

            var view = Object.Instantiate(_localCreator.Config.Prefab);
            var entityComponentFactory = new EntityComponentFactory(entity);
            var root = await _localCreator.Create<IPlayerRoot>(view, new[] { entityComponentFactory });

            var player = new NetworkPlayer(entity, root);
            await _dynamicEntityFactory.Send(entity, null);
            _playersList.Add(player);

            return player;
        }

        public async UniTaskVoid OnRemoteCreated(int objectId, RagonEntity entity)
        {
            var view = Object.Instantiate(_remoteCreator.Config.Prefab);
            var entityComponentFactory = new EntityComponentFactory(entity);
            var root = await _remoteCreator.Create<IPlayerRoot>(view, new[] { entityComponentFactory });

            var player = new NetworkPlayer(entity, root);
            _playersList.Add(player);
        }

        public void AssignId(ushort id)
        {
            _id = id;
        }
    }
}