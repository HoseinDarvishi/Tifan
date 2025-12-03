using System.ComponentModel.DataAnnotations.Schema;

namespace Tifan.Order.Models;

public class OrderItem 
{
    public Guid Id { get; private set; }
    public Guid OrderId { get; set; }

    [ForeignKey(nameof(OrderId))]
    public Order Order { get; set; }
}

