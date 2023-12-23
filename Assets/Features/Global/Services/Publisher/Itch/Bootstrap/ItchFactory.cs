using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Global.Audio.Player.Runtime;
using Global.Localizations.Runtime;
using Global.Publisher.Abstract.Bootstrap;
using Global.Publisher.Abstract.DataStorages;
using Global.Publisher.Abstract.Languages;
using Global.Publisher.Abstract.Purchases;
using Global.Publisher.Itch.Common;
using Global.Publisher.Itch.DataStorages;
using Global.Publisher.Itch.Languages;
using Internal.Services.Options.Implementations;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Publisher.Itch.Bootstrap
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ItchRoutes.ServiceName, menuName = ItchRoutes.ServicePath)]
    public class ItchFactory : PublisherSdkFactory
    {
        public override async UniTask Create(IServiceCollection builder, IScopeUtils utils)
        {
            var options = utils.Options.GetOptions<PlatformOptions>();

            builder.Register<ItchDataStorage>()
                .As<IDataStorage>()
                .WithParameter(GetSaves())
                .AsCallbackListener();

            builder.Register<ItchSystemLanguageProvider>()
                .As<ISystemLanguageProvider>()
                .AsCallbackListener();

            if (options.IsEditor == true)
            {
                builder.Register<ItchLanguageDebugAPI>()
                    .As<IItchLanguageAPI>();
            }
            else
            {
                builder.Register<ItchLanguageExternAPI>()
                    .As<IItchLanguageAPI>();
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