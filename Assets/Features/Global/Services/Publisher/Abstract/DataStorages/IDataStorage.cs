using Cysharp.Threading.Tasks;

namespace Global.Publisher.Abstract.DataStorages
{
    public interface IDataStorage
    {
        UniTask<T> GetEntry<T>(string key) where T : class;
        UniTask Save(IStorageEntry payload, string key);
    }
}