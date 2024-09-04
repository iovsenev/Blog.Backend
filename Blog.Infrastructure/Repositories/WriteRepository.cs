using Blog.Domain.Common;
using Blog.Infrastructure.DbContexts;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace Blog.Infrastructure.Repositories;
public abstract class WriteRepository<TEntity> : Repository<WriteDbContext>, IWriteRepository<TEntity> where TEntity : BaseEntity
{
    private DbSet<TEntity> _entities;

    protected WriteRepository(WriteDbContext DbContext) : base(DbContext)
    {
        _entities = _DbContext.Set<TEntity>();
    }

    public virtual async Task<Result<TEntity, Error>> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        var entity = await _entities.FirstOrDefaultAsync(predicate, cancellationToken);
        if (entity is null)
            return ErrorFactory.General.NotFound("Entity not found");
        return entity;
    }

    public virtual IQueryable<TEntity> GetAllBy(Expression<Func<TEntity,bool>> predicate)
    {
        return _entities.Where(predicate).AsNoTracking();
    }

    public virtual async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await _entities.AddAsync(entity, cancellationToken);
    }

    public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
    {
        await _entities.AddRangeAsync(entities, cancellationToken);
    }

    public virtual void Update(TEntity entity)
    {
         _DbContext.Entry(entity).State = EntityState.Modified;
    }

    public virtual void Delete(TEntity entity)
    {
        _DbContext.Database.BeginTransaction();
        _entities.Remove(entity);
    }

    public virtual void DeleteRange(IEnumerable<TEntity> entities)
    {
        using var transaction = BeginTransaction();

        _entities.RemoveRange(entities);
        SaveChangingAsync(default).Wait();

        transaction.Commit();
    }

    public async Task<int>SaveChangingAsync(CancellationToken cancellationToken)
    {
        var result = await _DbContext.SaveChangesAsync(cancellationToken);
        return result;
    }

    public IDbContextTransaction BeginTransaction()
    {
        return _DbContext.Database.BeginTransaction();
    }
}

public class Repository<TContext> where TContext: DbContext
{
    
    protected TContext _DbContext;

    public Repository(TContext DbContext)
    {
        _DbContext = DbContext;
    }
}

public interface IWriteRepository<TEntity> where TEntity : BaseEntity
{
}

public interface IReadRepository<TEntity> where TEntity : BaseEntity
{
}