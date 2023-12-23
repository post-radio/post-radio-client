using Common.Tools.ObjectsPools.Runtime.Abstract;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Common.Tools.ObjectsPools.Runtime
{
    public class AsyncObjectProvider<T> :
        IAsyncObjectsPool,
        IAsyncObjectProvider<T> where T : IPoolObject
    {
        public AsyncObjectProvider(
            IAsyncObjectFactory<T> factory,
            int startupInstances,
            Transform parent)
        {
            _factory = factory;
            _startupInstances = startupInstances;
            _parent = parent;
        }

        private readonly IAsyncObjectFactory<T> _factory;

        private readonly Transform _parent;

        private readonly ObjectsRegistry<T> _registry = new();
        private readonly int _startupInstances;

        public async UniTask<T> Get(Vector2 position)
        {
            T poolObject;

            if (_registry.ContainsInactive() == true)
            {
                poolObject = _registry.GetInactive();
            }
            else
            {
                poolObject = await _factory.Create(Vector2.zero);
                poolObject.Construct(Return);
                MoveToParent(poolObject);
                _registry.OnActiveCreated(poolObject);
            }

            poolObject.GameObject.transform.position = position;
            poolObject.OnTaken();
            return poolObject;
        }

        public void Return(IPoolObject poolObject)
        {
            poolObject.GameObject.SetActive(false);
            poolObject.OnReturned();
            MoveToParent(poolObject);
            _registry.OnReturned(poolObject);
        }

        public IAsyncObjectProvider<T1> GetProvider<T1>()
        {
            return this as IAsyncObjectProvider<T1>;
        }

        public async UniTask Preload()
        {
            var tasks = new UniTask<T>[_startupInstances];

            for (var i = 0; i < _startupInstances; i++)
                tasks[i] = _factory.Create(Vector2.zero);

            var result = await UniTask.WhenAll(tasks);

            for (var i = 0; i < _startupInstances; i++)
            {
                var poolObject = result[i];

                poolObject.Construct(Return);
                MoveToParent(poolObject);
                poolObject.GameObject.SetActive(false);
                _registry.OnInactiveCreated(poolObject);
            }
        }

        public async UniTask Unload()
        {
            _registry.DestroyAll();
        }

        private void MoveToParent(IPoolObject poolObject)
        {
            poolObject.GameObject.transform.parent = _parent;
        }
    }
}