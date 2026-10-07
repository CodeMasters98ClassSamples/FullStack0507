namespace FullStack0507.MyWebApi.Models
{
    /// <summary>
    /// Modeling -> 
    /// </summary>
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Barcode { get; set; }

        public Product Add(string name, string description, decimal price)
        {
            return new Product { Name = name, Description = description, Price = price };
        }
    }
}
