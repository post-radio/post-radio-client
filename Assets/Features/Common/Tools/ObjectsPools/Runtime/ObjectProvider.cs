using Common.Tools.ObjectsPools.Runtime.Abstract;
using UnityEngine;

namespace Common.Tools.ObjectsPools.Runtime
{
    public class ObjectProvider<T> :
        IObjectsPool,
        IObjectProvider<T> where T : class, IPoolObject
    {
        public ObjectProvider(
            IObjectFactory<T> factory,
            int startupInstances,
            Transform parent)
        {
            _factory = factory;
            _startupInstances = startupInstances;
            _parent = parent;
        }

        private readonly IObjectFactory<T> _factory;

        private readonly Transform _parent;

        private readonly ObjectsRegistry<T> _registry = new();
        private readonly int _startupInstances;

        public T Get(Vector2 position)
        {
            T poolObject;

            if (_registry.ContainsInactive() == true)
            {
                poolObject = _registry.GetInactive();
            }
            else
            {
                poolObject = _factory.Create(Vector2.zero);
                poolObject.Construct(Return);
                MoveToParent(poolObject);
                _registry.OnActiveCreated(poolObject);
            }

            poolObject.GameObject.transform.position = position;

            return poolObject;
        }

        public void Return(IPoolObject poolObject)
        {
            poolObject.GameObject.SetActive(false);
            poolObject.OnReturned();
            MoveToParent(poolObject);
            _registry.OnReturned(poolObject);
        }

        public IObjectProvider<T1> GetProvider<T1>()
        {
            return this as IObjectProvider<T1>;
        }

        public void Preload()
        {
            for (var i = 0; i < _startupInstances; i++)
            {
                var poolObject = _factory.Create(Vector2.zero);

                poolObject.Construct(Return);
                MoveToParent(poolObject);
                poolObject.GameObject.SetActive(false);
                _registry.OnInactiveCreated(poolObject);
            }
        }

        public void Unload()
        {
            _registry.DestroyAll();
        }

        private void MoveToParent(IPoolObject poolObject)
        {
            poolObject.GameObject.transform.parent = _parent;
        }
    }
}