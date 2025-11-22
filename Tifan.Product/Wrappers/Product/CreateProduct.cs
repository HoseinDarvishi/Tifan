namespace Tifan.Product.Wrappers.Product;

public class CreateProduct
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Guid CategoryId { get; private set; }
    public string Image { get; private set; }
    public decimal Price { get; private set; }
}
