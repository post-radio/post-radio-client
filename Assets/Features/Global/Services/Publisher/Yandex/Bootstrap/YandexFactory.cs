using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Global.Audio.Player.Runtime;
using Global.Publisher.Abstract.Advertisment;
using Global.Publisher.Abstract.Bootstrap;
using Global.Publisher.Abstract.DataStorages;
using Global.Publisher.Abstract.Languages;
using Global.Publisher.Abstract.Leaderboards;
using Global.Publisher.Abstract.Purchases;
using Global.Publisher.Abstract.Reviews;
using Global.Publisher.Yandex.Advertisement;
using Global.Publisher.Yandex.Common;
using Global.Publisher.Yandex.DataStorages;
using Global.Publisher.Yandex.Debugs;
using Global.Publisher.Yandex.Debugs.Ads;
using Global.Publisher.Yandex.Debugs.Purchases;
using Global.Publisher.Yandex.Debugs.Reviews;
using Global.Publisher.Yandex.Languages;
using Global.Publisher.Yandex.Leaderboard;
using Global.Publisher.Yandex.Purchases;
using Global.Publisher.Yandex.Review;
using Global.UI.Localizations.Runtime;
using Internal.Services.Options.Implementations;
using Internal.Services.Scenes.Abstract;
using Internal.Services.Scenes.Data;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Publisher.Yandex.Bootstrap
{
    [InlineEditor]
    [CreateAssetMenu(fileName = YandexRoutes.ServiceName, menuName = YandexRoutes.ServicePath)]
    public class YandexFactory : PublisherSdkFactory
    {
        [SerializeField] private SceneData _debugScene;
        [SerializeField] private YandexCallbacks _callbacksPrefab;
        [SerializeField] private ShopProductsRegistry _productsRegistry;
        [SerializeField] private ProductLink _adsDisableProduct;

        public override async UniTask Create(IServiceCollection builder, IScopeUtils utils)
        {
            var yandexCallbacks = Instantiate(_callbacksPrefab, Vector3.zero, Quaternion.identity);
            yandexCallbacks.name = "YandexCallbacks";

            builder.RegisterComponent(yandexCallbacks);

            RegisterModules(builder);

            var options = utils.Options.GetOptions<PlatformOptions>();
            
            if (options.IsEditor == true)
                await RegisterEditorApis(builder, utils.SceneLoader, yandexCallbacks);
            // else
            //     RegisterBuildApis(builder);
        }

        private void RegisterModules(IServiceCollection builder)
        {
            builder.Register<Ads>()
                .WithParameter<IProductLink>(_adsDisableProduct)
                .As<IAds>();

            var saves = GetSaves();

            builder.Register<DataStorage>()
                .As<IDataStorage>()
                .WithParameter(saves)
                .AsCallbackListener();

            builder.Register<SystemLanguageProvider>()
                .As<ISystemLanguageProvider>();

            builder.Register<LeaderboardsProvider>()
                .As<ILeaderboardsProvider>();

            builder.Register<Reviews>()
                .As<IReviews>();

            builder.Register<Payments>()
                .WithParameter(_productsRegistry)
                .As<IPayments>();
        }

        private async UniTask RegisterEditorApis(
            IServiceCollection builder,
            ISceneLoader sceneLoader,
            YandexCallbacks callbacks)
        {
            var loadResult = await sceneLoader.LoadTyped<YandexDebugCanvas>(_debugScene);

            var canvas = loadResult.Searched;

            canvas.Ads.Construct(callbacks);
            canvas.Reviews.Construct(callbacks);
            canvas.Purchase.Construct(callbacks);

            builder.Register<AdsDebugAPI>()
                .As<IAdsAPI>()
                .WithParameter<IAdsDebug>(canvas.Ads);

            builder.Register<StorageDebugAPI>()
                .As<IStorageAPI>();

            builder.Register<LanguageDebugAPI>()
                .As<ILanguageAPI>();

            builder.Register<LeaderboardsDebugAPI>()
                .As<ILeaderboardsAPI>();

            builder.Register<PurchasesDebugAPI>()
                .As<IPurchasesAPI>()
                .WithParameter(_productsRegistry)
                .WithParameter<IPurchaseDebug>(canvas.Purchase);

            builder.Register<ReviewsDebugAPI>()
                .As<IReviewsAPI>()
                .WithParameter<IReviewsDebug>(canvas.Reviews);
        }

        private void RegisterBuildApis(IServiceCollection builder)
        {
            builder.Register<AdsExternAPI>()
                .As<IAdsAPI>();

            builder.Register<StorageExternAPI>()
                .As<IStorageAPI>();

            builder.Register<LanguageExternAPI>()
                .As<ILanguageAPI>();

            builder.Register<LeaderboardsExternAPI>()
                .As<ILeaderboardsAPI>();

            builder.Register<PurchasesExternAPI>()
                .As<IPurchasesAPI>();

            builder.Register<ReviewsExternAPI>()
                .As<IReviewsAPI>();
        }

        private IStorageEntry[] GetSaves()
        {
            return new IStorageEntry[]
            {
                new VolumeSave(),
                new LanguageSave(),
                new PurchasesSave(),
            };
        }
    }
}