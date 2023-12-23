using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Global.UI.Nova.Common;
using Global.UI.Nova.InputManagers.Abstract;
using Global.UI.Nova.InputManagers.Logs;
using Global.UI.Nova.InputManagers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.UI.Nova.Compose
{
    [InlineEditor]
    [CreateAssetMenu(fileName = NovaRoutes.ComposeName, menuName = NovaRoutes.ComposePath)]
    public class NovaCompose : ScriptableObject, IServiceFactory
    {
        [SerializeField] private InputManagerLogSettings _logSettings;
        
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<InputManagerLogger>()
                .WithParameter(_logSettings);
            
            services.Register<NovaIuiInputManager>()
                .As<IUIInputManager>()
                .AsCallbackListener();
        }
    }
}