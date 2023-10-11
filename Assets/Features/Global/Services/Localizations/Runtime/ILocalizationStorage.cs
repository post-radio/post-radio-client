using System.Collections.Generic;
using Global.Localizations.Texts;

namespace Global.Localizations.Runtime
{
    public interface ILocalizationStorage
    {
        IReadOnlyList<LanguageTextData> GetDatas();
    }
}