namespace TifanBasket.Models;

public class Basket
{
    private Basket() { }
    public Basket(string userId)
    {
        UserId = userId;
    }

    public Guid Id { get; set; }
    public string UserId { get; private set; }

    public ICollection<BasketItem> Items { get; set; }

    public void AddItem(BasketItem item) 
    {
        if(Items == null) 
            Items = new List<BasketItem>();

        Items.Add(new BasketItem(item.BasketId,item.ProductId,item.ProductName,item.UnitPrice,item.Quantity,item.ImageUrl));
    }

    public void AddItem(ICollection<BasketItem> items)
    {
        if (items == null) return;
        foreach (var item in items)
            AddItem(item);
    }
}
