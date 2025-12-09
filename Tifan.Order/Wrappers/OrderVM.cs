namespace Tifan.Order.Wrappers
{
    public class OrderVM
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public DateTime OrderPlaced { get; set; }
        public bool OrderPaid { get; set; }
        public List<OrderItemVM> OrderItems { get; set; }

        public decimal TotalPrice => OrderItems?.Sum(x => x.ProductPrice * x.Quantity) ?? 0;
    }
}