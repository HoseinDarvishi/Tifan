namespace Tifan.Discount.Wrappers;

public class DiscountCodeVM
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public bool IsExpired { get; set; }
    public int Amount { get; set; }
}