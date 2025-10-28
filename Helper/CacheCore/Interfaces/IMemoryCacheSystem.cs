namespace Helper.CacheCore.Interfaces
{
    public interface IMemoryCacheSystem
    {
        void AddOrUpdate<T>(string key, T value);
        void AddOrUpdate<T>(string key, T value, TimeSpan expiration);
        bool TryGetValue<T>(string key, out T value);
        bool Remove(string key);
        void Clear();
    }
}