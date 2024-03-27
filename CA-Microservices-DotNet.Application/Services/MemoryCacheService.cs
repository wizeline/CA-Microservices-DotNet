using CA_Microservices_DotNet.Domain.Interfaces.Services;
using Microsoft.Extensions.Caching.Memory;

namespace CA_Microservices_DotNet.Application.Services;

public class MemoryCacheService : IMemoryCacheService
{
    private readonly IMemoryCache _memoryCache = default!;

    public MemoryCacheService(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    ///<inheritdoc/>
    public TValue Set<TValue>(string key, TValue value, TimeSpan Expiration)
    {
        return _memoryCache.Set(key, value, Expiration);
    }

    ///<inheritdoc/>
    public bool TryGetValue<TValue>(string key, out TValue? value)
    {
        if (_memoryCache.TryGetValue(key, out TValue? cache))
        {
            value = cache;
            return true;
        }

        value = default;
        return false;
    }
}
