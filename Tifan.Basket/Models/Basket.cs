using System.ComponentModel.DataAnnotations.Schema;

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
}

public class BasketItem
{
    private BasketItem() { }

    public BasketItem(Guid basketId, Guid productId, string productName, string unitPrice, int quantity, string imageUrl)
    {
        BasketId = basketId;
        ProductId = productId;
        ProductName = productName;
        UnitPrice = unitPrice;
        Quantity = quantity;
        ImageUrl = imageUrl;
    }

    public Guid BasketId { get; private set; }
    public Guid ProductId { get; private set; }
    public string ProductName { get; private set; }
    public string UnitPrice { get; private set; }
    public int Quantity { get; private set; }
    public string ImageUrl { get; private set; }

    [ForeignKey(nameof(BasketId))]
    public Basket Basket { get; private set; }


    public void SetQuantity(int quantity)
    {
        Quantity = quantity;
    }
}
