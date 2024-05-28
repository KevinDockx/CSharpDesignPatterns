namespace EnterprisePatterns.Repositories;

public interface IRepository<T>
{
    Task<T?> Get(int id);

    Task<IEnumerable<T>> GetAll();
    void Add(T entity);

    void Delete(T entity);

    void Update(T entity);
    Task SaveChanges();
}
