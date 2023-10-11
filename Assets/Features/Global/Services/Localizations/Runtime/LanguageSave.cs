using System;
using Global.Localizations.Definition;
using Global.Publisher.Abstract.DataStorages;
using Newtonsoft.Json;

namespace Global.Localizations.Runtime
{
    public class LanguageSave : IStorageEntry
    {
        public LanguageSavesPayload Value = new()
        {
            IsOverriden = false,
            Language = Language.Ru
        };
        
        public const string Key = "language";

        public string SaveKey => Key;
        
        public event Action Changed;
        
        public void CreateDefault()
        {
            Value = new LanguageSavesPayload()
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