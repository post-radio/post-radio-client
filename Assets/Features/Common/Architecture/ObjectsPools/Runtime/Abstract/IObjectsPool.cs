namespace Common.Architecture.ObjectsPools.Runtime.Abstract
{
    public interface IObjectsPool
    {
        IObjectProvider<T> GetProvider<T>();
        void Preload();
        void Unload();
    }
}