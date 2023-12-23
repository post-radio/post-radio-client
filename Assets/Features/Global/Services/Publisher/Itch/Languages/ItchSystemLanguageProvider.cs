using Global.Localizations.Definition;
using Global.Publisher.Abstract.Languages;

namespace Global.Publisher.Itch.Languages
{
    public class ItchSystemLanguageProvider : ISystemLanguageProvider
    {
        public ItchSystemLanguageProvider(IItchLanguageAPI api)
        {
            _externAPI = api;
        }

        private readonly IItchLanguageAPI _externAPI;

        private bool _isLanguageReceived;
        private Language _selected;

        public Language GetLanguage()
        {
            if (_isLanguageReceived == true)
                return _selected;

            var raw = _externAPI.GetLanguage_Internal();
            _isLanguageReceived = true;

            return raw switch
            {
                "ru" => Language.Ru,
                "en" => Language.Eng,
                _ => Language.Ru
            };
        }
    }
}