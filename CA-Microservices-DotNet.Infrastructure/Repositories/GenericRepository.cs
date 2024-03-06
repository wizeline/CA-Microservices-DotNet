using CA_Microservices_DotNet.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CA_Microservices_DotNet.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly MyDbContext _dbContext;

    public GenericRepository(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<T> Add(T entity, CancellationToken cancellationToken = default)
    {
        _dbContext.Entry(entity).State = EntityState.Added;
        await _dbContext.AddAsync(entity, cancellationToken);

        return entity;
    }

    public async Task DeleteById(int entityId, CancellationToken cancellationToken = default)
    {
        var dbSet = _dbContext.Set<T>();
       
        var entityToDelete = await _dbContext.Set<T>()
            .FindAsync(entityId, cancellationToken) 
                ?? throw new KeyNotFoundException("The entity was not found");

        dbSet.Remove(entityToDelete);
    }

    /// <inheritdoc/>
    public async Task<T> GetById(int entityId, CancellationToken cancellationToken = default)
    {
        var entity = await _dbContext.Set<T>().FindAsync(entityId, cancellationToken)
            ?? Activator.CreateInstance<T>();
        
        return entity;
    }

    /// <inheritdoc/>
    public async Task<List<T>> Get(
        Expression<Func<T, bool>>? filter = null,
        string[]? includeProperties = default,
        CancellationToken cancellationToken = default)
    {
        IQueryable<T> query = _dbContext.Set<T>();

        if (filter is not null)
        {
            query = query.Where(filter);
        }

        if (includeProperties is not null && includeProperties.Length > 0)
        {
            foreach (var property in includeProperties)
            {
                query = query.Include(property);
            }
        }

        return await query
                .AsNoTracking()
                .ToListAsync(cancellationToken);
    }

    public void Update(T entity)
    {
        _dbContext.Set<T>().Update(entity);
    }
}

