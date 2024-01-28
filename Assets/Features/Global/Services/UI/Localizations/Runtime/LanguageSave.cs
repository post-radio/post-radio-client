using System;
using Global.Publisher.Abstract.DataStorages;
using Global.UI.Localizations.Definition;
using Newtonsoft.Json;

namespace Global.UI.Localizations.Runtime
{
    public class LanguageSave : IStorageEntry
    {
        public LanguageSavesPayload Value = new()
        {
            IsOverriden = false,
            Language = Language.Eng
        };

        public const string Key = "language";

        public string SaveKey => Key;

        public event Action Changed;

        public void CreateDefault()
        {
            Value = new LanguageSavesPayload
            {
                IsOverriden = false,
                Language = Language.Ru
            };
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(Value);
        }

        public void Deserialize(string raw)
        {
            Value = JsonConvert.DeserializeObject<LanguageSavesPayload>(raw);
        }

        public void OnChanged()
        {
            Changed?.Invoke();
        }
    }

    [Serializable]
    public class LanguageSavesPayload
    {
        public bool IsOverriden;
        public Language Language;
    }
}