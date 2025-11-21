namespace Tifan.Product.Models
{
    public class Product 
    {
        private Product()
        {
            
        }

        public Product(string name, string description, string image, decimal price, Guid categoryId)
        {
            Name = name;
            Description = description;
            Image = image;
            Price = price;
            CategoryId = categoryId;
            CreateDate = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Guid CategoryId { get; private set; }
        public string Image { get; private set; }
        public decimal Price { get; private set; }
        public DateTime CreateDate { get; set; }

        public Category Category { get; private set; }


        public void Edit(string name, string description, string image, decimal price, Guid categoryId)
        {
            Name = name;
            Description = description;
            Image = image;
            Price = price;
            CategoryId = categoryId;
        }
    }
}
