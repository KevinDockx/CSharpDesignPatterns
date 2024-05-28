
using EnterprisePatterns.DbContexts;

namespace EnterprisePatterns.UnitsOfWork;

public abstract class UnitOfWork(OrderDbContext orderDbContext) : IUnitOfWork
{
    private readonly OrderDbContext _orderDbContext = orderDbContext;

    public async Task CommitAsync()
    {
        await _orderDbContext.SaveChangesAsync();
    }

    public void Rollback()
    {
        _orderDbContext.ChangeTracker.Clear();
    }
}
