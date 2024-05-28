using System.ComponentModel.DataAnnotations.Schema;

namespace EnterprisePatterns.Entities;

[Table("OrderLines")]
public class OrderLine(string product, int amount)
{
    public int Id { get; set; } 
    public string Product { get; set; } = product;
    public int Amount { get; set; } = amount;
    public int OrderId { get; set; } 
    public Order Order { get; set; } = null!;
}
