
namespace CA_Microservices_DotNet.Domain.Interfaces.Repositories;

public interface IGenericRepository<TEntity> where TEntity : class
{
    ///// <summary>
    ///// Adds an entity to the DbContext.
    ///// </summary>
    ///// <param name="entity">Entity to be added</param>
    ///// <param name="cancellationToken"></param>
    ///// <returns></returns>
    //Task<TEntity> Add(TEntity entity, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Gets and entity from DB by its id.
    /// </summary>
    /// <param name="entityId"></param>
    /// <param name="includeProperties"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TEntity> Get(int entityId, string[]? includeProperties = default, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Gets all table records
    /// </summary>
    /// <param name="includeProperties"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<TEntity>> GetAll(string[]? includeProperties = default, CancellationToken cancellationToken = default);
    
    ///// <summary>
    ///// Deletes an entity by its id.
    ///// </summary>
    ///// <param name="entityId"></param>
    ///// <param name="cancellationToken"></param>
    ///// <returns></returns>
    //Task DeleteById(int entityId, CancellationToken cancellationToken = default);
    
    ///// <summary>
    ///// Updates the entity.
    ///// </summary>
    ///// <param name="entity"></param>
    ///// <param name="cancellationToken"></param>
    //void Update(TEntity entity, CancellationToken cancellationToken = default);
}
