using EnterprisePatterns.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace EnterprisePatterns.Repositories;

public class GenericEFCoreRepository<T> : IRepository<T> where T : class
{
    private readonly OrderDbContext _dbContext;
    private DbSet<T> _dbSet;

    public GenericEFCoreRepository(OrderDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task<T?> Get(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task SaveChanges()
    {
        await _dbContext.SaveChangesAsync();
    }

    public void Update(T entity)
    {
        // no code required
    }
}
