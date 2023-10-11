using System;
using System.Collections.Generic;
using Global.Publisher.Abstract.DataStorages;
using Newtonsoft.Json;

namespace Global.Publisher.Abstract.Purchases
{
    public class PurchasesSave : IStorageEntry
    {
        public const string Key = "purchases";

        private List<string> _purchases;

        public string SaveKey => Key;
        public IReadOnlyList<string> Purchases => _purchases;

        public event Action Changed;

        public void CreateDefault()
        {
            _purchases = new List<string>();
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(_purchases);
        }

        public void Deserialize(string raw)
        {
            _purchases = JsonConvert.DeserializeObject<List<string>>(raw);
        }

        public void OnPurchase(string id)
        {
            _purchases.Add(id);

            Changed?.Invoke();
        }
    }
}