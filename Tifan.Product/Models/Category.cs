namespace Tifan.Product.Models;

public class Category
{
    private Category() {}

    public Category(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public ICollection<Product> Products { get; set; }

    public void Edit(string name, string description)
    {
        Name = name;
        Description = description;
    }
}
