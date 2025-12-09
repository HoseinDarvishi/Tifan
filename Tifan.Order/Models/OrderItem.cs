using System.ComponentModel.DataAnnotations.Schema;

namespace Tifan.Order.Models;

public class OrderItem 
{
    public Guid Id { get; private set; }
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public int Quantity { get; set; }

    [ForeignKey(nameof(OrderId))]
    public Order Order { get; set; }

    public void SetQuantity(int quantity)
    {
        Quantity = quantity;
    }
}

