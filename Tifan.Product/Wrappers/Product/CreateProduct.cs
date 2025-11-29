namespace Tifan.Product.Wrappers.Product;

public class CreateProduct
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
    public string Image { get; set; }
    public decimal Price { get; set; }
}
