namespace Tifan.Discount.Models
{
    public class DiscountCode
    {
        private DiscountCode()
        {
            
        }

        public DiscountCode(string code, int amount)
        {
            Code = code;
            Amount = amount;
            IsExpired = false;
        }

        public Guid Id { get; private set; }
        public string Code { get; private set; }
        public bool IsExpired { get; private set; }
        public int Amount { get; private set; }
    }
}