using System;
using Cysharp.Threading.Tasks;
using GamePlay.Network.Room.SceneCollectors.Runtime;
using Ragon.Client;

namespace GamePlay.Network.Room.Entities.Factory
{
    public class SceneEntityFactory : ISceneEntityFactory
    {
        public SceneEntityFactory(IGameSceneCollector sceneCollector)
        {
            _sceneCollector = sceneCollector;
        }

        private readonly IGameSceneCollector _sceneCollector;

        private const int _type = 0;

        private ushort _counter = 1;

        public async UniTask AttachAsync(RagonEntity entity)
        {
            var awaiter = new AttachAwaiter(entity);

            await awaiter.WaitAttachAsync();
        }

        public async UniTask<RagonEntity> Create()
        {
            var entity = CreateLocal();

            var awaiter = new AttachAwaiter(entity);

            await awaiter.WaitAttachAsync();

            return entity;
        }

        public async UniTask<RagonEntity> Create(params RagonProperty[] properties)
        {
            var entity = CreateLocal();

            foreach (var property in properties)
                entity.State.AddProperty(property);
            
            var awaiter = new AttachAwaiter(entity);

            await awaiter.WaitAttachAsync();

            return entity;
        }

        public RagonEntity CreateLocal()
        {
            if (_sceneCollector.IsCollected == true)
                throw new ArgumentException("Entities are already collected");

            var entity = new RagonEntity(_type, _counter);

            _sceneCollector.AddEntity(entity);

            _counter++;

            return entity;
        }
    }
}