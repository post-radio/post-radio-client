using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Network.Room.Entities.Factory;
using GamePlay.Network.Room.EventLoops.Runtime;
using Ragon.Client;
using Ragon.Client.Unity;
using UnityEngine;

namespace GamePlay.Audio.Test
{
    public class TestEntityFactory : MonoBehaviour, IServiceFactory, INetworkSceneEntityCreationListener
    {
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            utils.Callbacks.Listen(this);
        }

        private RagonString _property;
        private RagonEntity _entity;

        public async UniTask OnSceneEntityCreation(ISceneEntityFactory factory)
        {
            _property = new RagonString(100);
            _entity = await factory.Create(_property);
        }

        private void Update()
        {
            if (_property == null || _entity == null || _entity.IsAttached == false)
                return;

            _property.Value = "asdads";
        }
    }
}