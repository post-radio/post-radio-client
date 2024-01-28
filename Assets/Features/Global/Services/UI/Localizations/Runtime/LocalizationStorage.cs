using System.Collections.Generic;
using Common.DataTypes.Collections.ScriptableRegistries;
using Global.UI.Localizations.Common;
using Global.UI.Localizations.Texts;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.UI.Localizations.Runtime
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