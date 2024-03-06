using CA_Microservices_DotNet.Domain.Entities;

namespace CA_Microservices_DotNet.Domain.Interfaces;

/// <summary>
/// Use UnitOfWork for commands like Add, Remove, Update to perform SOLID transactions
/// call SaveChanges() only if everything went well in the workflow.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Expose IQueryable to access table data. 
    /// </summary>
    IQueryable<Review> Reviews { get; }
    IQueryable<Book> Books { get; }

    /// <summary>
    /// Adds an entity to the DbContext.
    /// </summary>
    /// <param name="entity">Entity to be added</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    void Add(object entity);

    /// <summary>
    /// Deletes an entity by its id.
    /// </summary>
    /// <param name="entityId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    void Remove(object entity);

    /// <summary>
    /// Updates the entity.
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    void Update(object entity);

    /// <summary>
    /// Executes all the changes in the ChangeTracker against the DB.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
