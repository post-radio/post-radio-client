using System;
using Global.Publisher.Abstract.DataStorages;
using Newtonsoft.Json;

namespace Global.Publisher.Abstract.Advertisment
{
    public class AdsSave : IStorageEntry
    {
        public const string Key = "ads";

        private bool _isDisabled;

        public string SaveKey => Key;
        public bool IsDisabled => _isDisabled;
        
        public event Action Changed;
        
        public void CreateDefault()
        {
            _isDisabled = false;
        }

        public void OnDisabled()
        {
            _isDisabled = true;
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(_isDisabled);
        }

        public void Deserialize(string raw)
        {
            _isDisabled = JsonConvert.DeserializeObject<bool>(raw);
        }
    }
}