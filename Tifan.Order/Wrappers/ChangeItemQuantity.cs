namespace Tifan.Order.Wrappers
{
    public class ChangeItemQuantity
    {
        public Guid OrderItemId { get; set; }
        public int Quantity { get; set; }
    }
}
