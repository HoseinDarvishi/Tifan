namespace Tifan.Order.Wrappers
{
    public class AddOrderItem 
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public Guid OrderId { get; set; }
    }
}