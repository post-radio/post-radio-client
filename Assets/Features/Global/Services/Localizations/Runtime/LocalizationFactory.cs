using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Global.Localizations.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Localizations.Runtime
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