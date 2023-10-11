using Global.Localizations.Definition;

namespace Global.Localizations.Runtime
{
    public interface ILocalization
    {
        Language Language { get; }
        void Set(Language language);
        Language GetNext(Language language);
    }
}