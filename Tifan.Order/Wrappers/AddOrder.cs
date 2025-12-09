namespace Tifan.Order.Wrappers
{
    public class AddOrder
    {
        public string UserId { get; set; }
        public List<AddOrderItem> Items { get; set; }
    }
}