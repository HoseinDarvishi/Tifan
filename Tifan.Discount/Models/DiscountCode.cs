namespace Tifan.Discount.Models
{
    public class DiscountCode
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public bool IsExpired { get; set; }
        public decimal Amount { get; set; }
    }
}