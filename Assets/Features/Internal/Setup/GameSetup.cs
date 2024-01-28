using Common.Architecture.Scopes.Factory;
using Common.Architecture.Scopes.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using Global.Config.Runtime;
using Internal.Scope;
using UnityEngine;
using VContainer;

namespace Internal.Setup
{
    [DisallowMultipleComponent]
    public class GameSetup : MonoBehaviour
    {
        [SerializeField] private InternalScopeConfig _internal;
        [SerializeField] private GlobalScopeConfig _global;
        [SerializeField] private GameObject _loading;

        private void Awake()
        {
            Setup().Forget();
        }

        private async UniTask Setup()
        {
            var internalScopeLoader = new InternalScopeLoader(_internal);
            var internalScope = await internalScopeLoader.Load();
            var scopeLoaderFactory = internalScope.Container.Resolve<IScopeLoaderFactory>();
            var scopeLoader = scopeLoaderFactory.Create(_global, internalScope);

            var scopeLoadResult = await scopeLoader.Load();
            
            await scopeLoadResult.Callbacks[CallbackStage.Construct].Run();
            await scopeLoadResult.Callbacks[CallbackStage.SetupComplete].Run();

            _loading.SetActive(false);
        }
    }
}