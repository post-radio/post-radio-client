using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Global.UI.Localizations.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.UI.Localizations.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LocalizationRoutes.ServiceName, menuName = LocalizationRoutes.ServicePath)]
    public class LocalizationFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [Indent] private LocalizationStorage _storage;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<Localization>()
                .WithParameter<ILocalizationStorage>(_storage)
                .As<ILocalization>()
                .AsCallbackListener();

            services.Register<LanguageConverter>()
                .As<ILanguageConverter>();
        }
    }
}