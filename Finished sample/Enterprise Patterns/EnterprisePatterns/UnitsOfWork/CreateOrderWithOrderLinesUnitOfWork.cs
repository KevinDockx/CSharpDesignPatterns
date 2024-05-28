using EnterprisePatterns.DbContexts;
using EnterprisePatterns.Entities;
using EnterprisePatterns.Repositories;

namespace EnterprisePatterns.UnitsOfWork;

public class CreateOrderWithOrderLinesUnitOfWork(OrderDbContext orderDbContext,
    IRepository<Order> orderRepository,
    IOrderLineRepository orderLineRepository)
    : UnitOfWork(orderDbContext)
{
    public IRepository<Order> OrderRepository { get; } = orderRepository;
    public IOrderLineRepository OrderLineRepository { get; } = orderLineRepository;
}
