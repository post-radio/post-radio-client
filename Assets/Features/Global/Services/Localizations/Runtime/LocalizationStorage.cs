using System.Collections.Generic;
using Common.Serialization.ScriptableRegistries;
using Global.Localizations.Common;
using Global.Localizations.Texts;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Localizations.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LocalizationRoutes.StorageName, menuName = LocalizationRoutes.StoragePath)]
    public class LocalizationStorage : ScriptableRegistry<LanguageTextData>, ILocalizationStorage
    {
        public IReadOnlyList<LanguageTextData> GetDatas()
        {
            return Objects;
        }
    }
}