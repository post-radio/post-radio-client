using Global.Localizations.Definition;

namespace Global.Localizations.Runtime
{
    public interface ILanguageConverter
    {
        string ToString(Language language);
    }
}