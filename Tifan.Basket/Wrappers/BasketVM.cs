namespace Tifan.Basket.Wrappers;

public class BasketVM
{
    public Guid Id { get; set; }
    public List<BasketItemVM> Items { get; set; } = new List<BasketItemVM>();

    public decimal TotalPrice => Items?.Sum(i => i.Quantity * i.UnitPrice)??0;
}
