using System.Collections.Generic;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using Global.Publisher.Abstract.DataStorages;
using Newtonsoft.Json;
using UnityEngine;

namespace Global.Publisher.Itch.DataStorages
{
    public class WebDataStorage : IDataStorage, IScopeAwakeAsyncListener
    {
        public WebDataStorage(IStorageEntry[] entries)
        {
            foreach (var entry in entries)
            {
                entry.Changed += OnEntryChanged;
                _entries[entry.SaveKey] = entry;
            }
        }

        private const string Key = "save";
        private readonly Dictionary<string, IStorageEntry> _entries = new();

        public async UniTask OnAwakeAsync()
        {
            foreach (var (_, entry) in _entries)
                entry.CreateDefault();

            if (PlayerPrefs.HasKey(Key) == false)
                PlayerPrefs.SetString(Key, JsonConvert.SerializeObject(new Dictionary<string, string>()));
            
            var raw = PlayerPrefs.GetString(Key);
            var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(raw);

            foreach (var (key, rawEntry) in data)
                _entries[key].Deserialize(rawEntry);
        }

        public UniTask<T> GetEntry<T>(string key) where T : class
        {
            var entry = _entries[key];

            return UniTask.FromResult(entry as T);
        }

        public UniTask Save(IStorageEntry payload, string saveKey)
        {
            var save = new Dictionary<string, string>();

            foreach (var (key, entry) in _entries)
            {
                var rawEntry = entry.Serialize();
                save[key] = rawEntry;
            }

            save[saveKey] = payload.Serialize();
            _entries[saveKey] = payload;

            var json = JsonConvert.SerializeObject(save);

            PlayerPrefs.SetString(Key, json);

            return UniTask.CompletedTask;
        }

        private void OnEntryChanged()
        {
            var save = new Dictionary<string, string>();

            foreach (var (key, entry) in _entries)
            {
                var rawEntry = entry.Serialize();
                save[key] = rawEntry;
            }

            var json = JsonConvert.SerializeObject(save);
            PlayerPrefs.SetString(Key, json);
        }
    }
}