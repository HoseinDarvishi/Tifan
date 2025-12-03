namespace Tifan.Order.Models;

public class Order
{
    private Order() { }

    public Order(string userId, List<OrderItem> items)
    {
        UserId = userId;
        OrderPlaced = DateTime.Now;
        OrderItems = items;
        OrderPaid = false;
    }

    public Guid Id { get; private set; }
    public string UserId { get; private set; }
    public DateTime OrderPlaced { get; private set; }
    public bool OrderPaid { get; private set; }
    public ICollection<OrderItem> OrderItems { get; private set; }
}

