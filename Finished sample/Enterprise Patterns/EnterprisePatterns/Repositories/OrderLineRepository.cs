using EnterprisePatterns.DbContexts;
using EnterprisePatterns.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnterprisePatterns.Repositories;

public class OrderLineRepository(OrderDbContext orderDbContext) : 
    GenericEFCoreRepository<OrderLine>(orderDbContext), IOrderLineRepository
{
    private readonly OrderDbContext _orderDbContext = orderDbContext;

    public async Task<IEnumerable<OrderLine>> GetAllByOrderId(int orderId)
    {
        return await _orderDbContext.OrderLines
            .Where(o => o.OrderId == orderId).ToListAsync();
    }
}

//public class OrderLineRepository(OrderDbContext orderDbContext) : IOrderLineRepository
//{
//    private readonly OrderDbContext _orderDbContext = orderDbContext;

//    public async Task<OrderLine?> Get(int id)
//    {
//        return await _orderDbContext.OrderLines
//            .FirstOrDefaultAsync(o => o.Id == id);
//    }

//    public async Task<IEnumerable<OrderLine>> GetAll()
//    {
//        return await _orderDbContext.OrderLines.ToListAsync();
//    }

//    public async Task<IEnumerable<OrderLine>> GetAllByOrderId(int orderId)
//    {
//        return await _orderDbContext.OrderLines
//            .Where(o => o.OrderId == orderId).ToListAsync();
//    }
//    public void Add(OrderLine entity)
//    {
//        _orderDbContext.OrderLines.Add(entity);
//    }
//    public void Update(OrderLine entity)
//    {
//        // no code here
//    }

//    public void Delete(OrderLine entity)
//    {
//        _orderDbContext.OrderLines.Remove(entity);
//    }

//    public async Task SaveChanges()
//    {
//        await _orderDbContext.SaveChangesAsync();
//    }
//}

