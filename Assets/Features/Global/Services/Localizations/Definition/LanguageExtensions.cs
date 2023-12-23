using System;

namespace Global.Localizations.Definition
{
    public static class LanguageExtensions
    {
        public static Language ParseLanguage(string value)
        {
            return value switch
            {
                "Eng" => Language.Eng,
                "Ru" => Language.Ru,
                _ => throw new ArgumentException()
            };
        }
    }
}