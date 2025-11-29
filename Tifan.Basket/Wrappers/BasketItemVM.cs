namespace Tifan.Basket.Wrappers;

public class BasketItemVM
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Guid BasketId { get; set; }
    public string PruductName { get; set; }
    public string ImageUrl { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; private set; }
}
