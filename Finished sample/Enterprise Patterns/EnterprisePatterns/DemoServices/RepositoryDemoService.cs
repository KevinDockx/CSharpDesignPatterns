using EnterprisePatterns.Entities;
using EnterprisePatterns.Repositories;

namespace EnterprisePatterns.Services;

public class RepositoryDemoService(IRepository<Order> _genericOrderRepository,
    IOrderLineRepository orderLineRepository)
{
    private readonly IRepository<Order> _genericOrderRepository = _genericOrderRepository;
    private readonly IOrderLineRepository _orderLineRepository = orderLineRepository;

    public async Task RunAsync()
    {
        // load order 
        var order = await _genericOrderRepository.Get(1);

        if (order != null)
        {
            // update order
            order.Description = "Updated description";
            // save changes 
            await _genericOrderRepository.SaveChanges();

            // create a new orderline for the previously fetched order 
            OrderLine orderLine = new("Skirt", 1) { OrderId = order.Id };
            _orderLineRepository.Add(orderLine);

            // save changes 
            await _orderLineRepository.SaveChanges();
        }
    }
}
