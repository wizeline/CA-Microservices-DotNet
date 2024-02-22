using CA_Microservices_DotNet.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

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
        var table = _dbContext.Set<T>();
       
        var entityToDelete = await _dbContext.Set<T>()
            .FindAsync(new object?[] { entityId, cancellationToken }, cancellationToken: cancellationToken) 
                ?? throw new KeyNotFoundException("The entity was not found");

        table.Remove(entityToDelete);
    }

    public async Task<T> Get(int entityId, string[]? includeProperties = default, CancellationToken cancellationToken = default)
    {
        var entity = await _dbContext.Set<T>()
            .FindAsync(new object?[] { entityId, cancellationToken }, cancellationToken: cancellationToken)
                ?? throw new KeyNotFoundException("The entity was not found");
        
        return entity;
    }

    public Task<List<T>> GetAll(string[]? includeProperties = default, CancellationToken cancellationToken = default)
    {
        var table = _dbContext.Set<T>().AsQueryable();
        if (includeProperties is null)
            return table.ToListAsync(cancellationToken);

        foreach (var property in includeProperties)
        {
            table.Include(property);
        }

        return table.ToListAsync(cancellationToken);
    }

    public void Update(T entity, CancellationToken cancellationToken = default)
    {
        _dbContext.Set<T>().Update(entity);
    }
}

