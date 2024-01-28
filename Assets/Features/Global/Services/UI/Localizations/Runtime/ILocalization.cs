using Global.UI.Localizations.Definition;

namespace Global.UI.Localizations.Runtime
{
    public interface ILocalization
    {
        Language Language { get; }
        void Set(Language language);
        Language GetNext(Language language);
    }
}