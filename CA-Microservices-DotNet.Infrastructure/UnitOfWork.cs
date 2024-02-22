using CA_Microservices_DotNet.Domain.Entities;
using CA_Microservices_DotNet.Domain.Interfaces;

namespace CA_Microservices_DotNet.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly MyDbContext _dbContext;

    #region IQueryables 
    
    public IQueryable<Review> Reviews => _dbContext.Reviews;

    public IQueryable<Book> Books => _dbContext.Books;

    #endregion

    public UnitOfWork(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    ///<inheritdoc/>
    public void Add(object entity)
    {
        if (entity is IEnumerable<object>)
        {
            _dbContext.Add(entity);
        }
        else
        {
            _dbContext.Add(entity);
        }
    }

    ///<inheritdoc/>
    public void Remove(object entity)
    {
        if(entity is IEnumerable<object>)
        {
            _dbContext.RemoveRange(entity);
        }
        else
        {
            _dbContext.Remove(entity);
        }
    }

    ///<inheritdoc/>
    public void Update(object entity)
    {
        _dbContext.Update(entity);
    }

    ///<inheritdoc/>
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
