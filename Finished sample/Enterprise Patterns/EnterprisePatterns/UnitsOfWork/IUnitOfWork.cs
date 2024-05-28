namespace EnterprisePatterns.UnitsOfWork;

public interface IUnitOfWork
{
    Task CommitAsync();
    void Rollback();
}
