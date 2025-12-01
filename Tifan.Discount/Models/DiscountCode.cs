namespace Tifan.Discount.Models
{
    public class DiscountCode
    {
        private DiscountCode()
        {
            
        }

        public DiscountCode(string code, decimal amount)
        {
            Code = code;
            Amount = amount;
            IsExpired = false;
        }

        public Guid Id { get; private set; }
        public string Code { get; private set; }
        public bool IsExpired { get; private set; }
        public decimal Amount { get; private set; }
    }
}