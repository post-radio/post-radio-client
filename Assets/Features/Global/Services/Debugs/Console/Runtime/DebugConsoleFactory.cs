using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Global.Debugs.Console.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Debugs.Console.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = DebugConsoleRoutes.ServiceName,
        menuName = DebugConsoleRoutes.ServicePath)]
    public class DebugConsoleFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [Indent] private DebugConsole _prefab;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var debugConsole = Instantiate(_prefab);
            debugConsole.name = "DebugConsole";

            services.RegisterComponent(debugConsole)
                .AsCallbackListener();

            utils.Binder.MoveToModules(debugConsole);
        }
    }
}