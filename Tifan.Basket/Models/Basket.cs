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
