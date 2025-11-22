using Tifan.Product.Wrappers.Category;

namespace Tifan.Product.Wrappers.Product;
public class ProductVM 
{
    public Guid Id { get; set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public CategoryVM Category { get; set; }
    public string Image { get; private set; }
    public decimal Price { get; private set; }
}