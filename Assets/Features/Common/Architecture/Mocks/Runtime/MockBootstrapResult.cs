using System.Collections.Generic;
using Common.Architecture.ScopeLoaders.Runtime;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using Global.System.LoadedHandler.Runtime;
using Internal.Services.Scenes.Abstract;
using Internal.Services.Scenes.Native;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;

namespace Common.Architecture.Mocks.Runtime
{
    public class MockBootstrapResult
    {
        public MockBootstrapResult(LifetimeScope parent)
        {
            Parent = parent;
            Resolver = parent.Container;
        }
        
        public readonly IObjectResolver Resolver;
        public readonly LifetimeScope Parent;

        public async UniTask RegisterLoadedScene(IScopeLoadResult loadResult)
        {
            var scenes = new List<ISceneLoadResult>(loadResult.Scenes);
            scenes.Add(new NativeSceneLoadResult(SceneManager.GetActiveScene()));

            var newResult = new ScopeLoadResult(loadResult.Scope, loadResult.Callbacks, scenes);
            
            var sceneHandler = Resolver.Resolve<ILoadedScenesHandler>();
            sceneHandler.OnLoaded(newResult);

            await loadResult.Callbacks[CallbackStage.Construct].Run();
            await loadResult.Callbacks[CallbackStage.SetupComplete].Run();
        }
    }
}