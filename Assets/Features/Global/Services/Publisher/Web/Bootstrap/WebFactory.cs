using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Global.Audio.Player.Runtime;
using Global.Localizations.Runtime;
using Global.Publisher.Abstract.Bootstrap;
using Global.Publisher.Abstract.Callbacks;
using Global.Publisher.Abstract.DataStorages;
using Global.Publisher.Abstract.Languages;
using Global.Publisher.Abstract.Purchases;
using Global.Publisher.Web.Common;
using Global.Publisher.Web.DataStorages;
using Global.Publisher.Web.Languages;
using Internal.Services.Options.Implementations;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Publisher.Web.Bootstrap
{
    [InlineEditor]
    [CreateAssetMenu(fileName = WebRoutes.ServiceName, menuName = WebRoutes.ServicePath)]
    public class WebFactory : PublisherSdkFactory
    {
        [SerializeField] private WebCallbacks _callbacksPrefab;

        public override async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var options = utils.Options.GetOptions<PlatformOptions>();

            var callbacks = Instantiate(_callbacksPrefab);

            services.RegisterInstance(callbacks)
                .As<IJsErrorCallback>();

            services.Register<WebDataStorage>()
                .As<IDataStorage>()
                .WithParameter(GetSaves())
                .AsCallbackListener();

            services.Register<WebSystemLanguageProvider>()
                .As<ISystemLanguageProvider>()
                .AsCallbackListener();

            if (options.IsEditor == true)
            {
                services.Register<WebLanguageDebugAPI>()
                    .As<IWebLanguageAPI>();
            }
            else
            {
                services.Register<WebLanguageExternAPI>()
                    .As<IWebLanguageAPI>();
            }
        }

        private IStorageEntry[] GetSaves()
        {
            return new IStorageEntry[]
            {
                new SoundSave(),
                new LanguageSave(),
                new PurchasesSave(),
            };
        }
    }
}