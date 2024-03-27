using Microsoft.Extensions.Caching.Memory;

namespace CA_Microservices_DotNet.Domain.Interfaces.Services;

public interface IMemoryCacheService
{
    ///<inheritdoc cref="IMemoryCache.TryGetValue(object, out object?)"/>
    bool TryGetValue<TValue>(string key, out TValue? value);

    ///<inheritdoc cref="CacheExtensions.Set{TItem}(IMemoryCache, object, TItem, TimeSpan)"/>
    TValue Set<TValue>(string key, TValue value, TimeSpan Expiration);
}
