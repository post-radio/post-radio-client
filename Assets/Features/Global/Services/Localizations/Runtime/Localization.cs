using System;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using Global.Localizations.Definition;
using Global.Publisher.Abstract.DataStorages;
using Global.Publisher.Abstract.Languages;

namespace Global.Localizations.Runtime
{
    public class Localization : IScopeEnableAsyncListener, ILocalization
    {
        public Localization(
            ILocalizationStorage storage,
            ISystemLanguageProvider systemLanguageProvider,
            IDataStorage dataStorage)
        {
            _storage = storage;
            _systemLanguageProvider = systemLanguageProvider;
            _dataStorage = dataStorage;
        }

        private readonly ILocalizationStorage _storage;
        private readonly ISystemLanguageProvider _systemLanguageProvider;
        private readonly IDataStorage _dataStorage;

        private Language _language;

        public Language Language => _language;

        public async UniTask OnEnabledAsync()
        {
            var saves = await _dataStorage.GetEntry<LanguageSave>(LanguageSave.Key);

            if (saves.Value.IsOverriden == true)
                _language = saves.Value.Language;
            else
                _language = _systemLanguageProvider.GetLanguage();

            var datas = _storage.GetDatas();

            foreach (var data in datas)
                data.SelectLanguage(_language);
        }

        public void Set(Language language)
        {
            _language = language;

            var payload = new LanguageSavesPayload
            {
                IsOverriden = true,
                Language = language
            };

            var save = new LanguageSave
            {
                Value = payload
            };

            _dataStorage.Save(save, LanguageSave.Key);

            var datas = _storage.GetDatas();

            foreach (var data in datas)
                data.SelectLanguage(_language);
        }

        public Language GetNext(Language language)
        {
            return language switch
            {
                Language.Ru => Language.Eng,
                Language.Eng => Language.Ru,
                _ => throw new ArgumentOutOfRangeException(nameof(language), language, null)
            };
        }
    }
}