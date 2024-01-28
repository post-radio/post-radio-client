using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Global.System.Updaters.Common;
using Global.System.Updaters.Delays;
using Global.System.Updaters.Logs;
using Global.System.Updaters.Runtime;
using Global.System.Updaters.Runtime.Abstract;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.System.Updaters.Setup
{
    [InlineEditor]
    [CreateAssetMenu(fileName = UpdaterRouter.ServiceName,
        menuName = UpdaterRouter.ServicePath)]
    public class UpdaterFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [Indent] private UpdaterLogSettings _logSettings;
        [SerializeField] [Indent] private Updater _prefab;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var updater = Instantiate(_prefab);
            updater.name = "Updater";

            services.Register<UpdaterLogger>()
                .WithParameter(_logSettings);

            services.RegisterComponent(updater)
                .As<IUpdater>()
                .As<IUpdateSpeedModifier>()
                .As<IUpdateSpeedSetter>()
                .AsSelfResolvable()
                .AsCallbackListener();

            services.Register<DelayRunner>()
                .As<IDelayRunner>();

            utils.Binder.MoveToModules(updater);
        }
    }
}