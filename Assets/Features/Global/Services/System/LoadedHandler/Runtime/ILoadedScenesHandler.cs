using Common.Architecture.ScopeLoaders.Runtime;
using Cysharp.Threading.Tasks;

namespace Global.System.LoadedHandler.Runtime
{
    public interface ILoadedScenesHandler
    {
        public void OnLoaded(IScopeLoadResult loaded);

        public UniTask Unload();

        public UniTask FinalizeUnloading();
    }
}