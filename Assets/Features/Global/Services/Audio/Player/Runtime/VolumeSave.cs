using System;
using Global.Publisher.Abstract.DataStorages;
using Newtonsoft.Json;

namespace Global.Audio.Player.Runtime
{
    [Serializable]
    public class VolumeSave : IStorageEntry
    {
        public const string Key = "sound";
        
        public SoundSavePayload Value;
        
        public string SaveKey => Key;
        
        public event Action Changed;

        public void CreateDefault()
        {
            Value = new SoundSavePayload
            {
                SoundVolume = 0.5f,
                MusicVolume = 0.5f
            };
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(Value);
        }

        public void Deserialize(string raw)
        {
            Value = JsonConvert.DeserializeObject<SoundSavePayload>(raw);
        }
    }

    [Serializable]
    public class SoundSavePayload
    {
        public float MusicVolume = 0.5f;
        public float SoundVolume = 0.5f;
    }
}