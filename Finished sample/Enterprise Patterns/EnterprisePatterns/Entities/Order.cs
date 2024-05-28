using System.ComponentModel.DataAnnotations.Schema;

namespace EnterprisePatterns.Entities;


[Table("Orders")]
public class Order(string? description)
{
    public int Id { get; set; }
    public string? Description { get; set; } = description;
    public ICollection<OrderLine> OrderLines { get; set; } = [];
} 