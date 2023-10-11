using System;

namespace Global.Publisher.Abstract.DataStorages
{
    public interface IStorageEntry
    {
        string SaveKey { get; }
        event Action Changed;

        void CreateDefault();
        string Serialize();
        void Deserialize(string raw);
    }
}