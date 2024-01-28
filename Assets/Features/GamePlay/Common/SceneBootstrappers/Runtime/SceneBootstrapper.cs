using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer.Unity;

namespace GamePlay.Common.SceneBootstrappers.Runtime
{
    [DisallowMultipleComponent]
    public class SceneBootstrapper :
        MonoBehaviour,
        ISceneBootstrapper,
        ISceneComponentBuildersStorage,
        IScopeBuiltListener
    {
        [SerializeField] private SceneComponentRegister[] _registers;
        [SerializeField] private SceneComponentBuilder[] _builders;

        public void Build(IServiceCollection builder, IScopeCallbacks callbacks)
        {
            foreach (var register in _registers)
                register.Register(builder);

            callbacks.Listen(this);
        }

        public void SetTargets(SceneComponentRegister[] registers, SceneComponentBuilder[] builders)
        {
            _registers = registers;
            _builders = builders;
        }

        public async UniTask OnContainerBuilt(LifetimeScope parent, ICallbackRegister callbacks)
        {
            var tasks = new UniTask[_builders.Length];

            for (var i = 0; i < tasks.Length; i++)
                tasks[i] = _builders[i].Build(parent, callbacks);

            await UniTask.WhenAll(tasks);
        }

        public void OnContainerBuilt(LifetimeScope scope)
        {
        }
    }
}