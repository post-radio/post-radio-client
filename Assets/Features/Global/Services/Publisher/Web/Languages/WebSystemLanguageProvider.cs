using Global.Localizations.Definition;
using Global.Publisher.Abstract.Languages;

namespace Global.Publisher.Itch.Languages
{
    public class WebSystemLanguageProvider : ISystemLanguageProvider
    {
        public WebSystemLanguageProvider(IWebLanguageAPI api)
        {
            _externAPI = api;
        }

        private readonly IWebLanguageAPI _externAPI;

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