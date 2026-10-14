namespace FullStack0507.MyWebApi.Models
{
    /// <summary>
    /// Modeling
    /// Class -> Properties , Methods
    /// </summary>
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Barcode { get; set; }

        public Product Add(string name, string description, decimal price, string barcode)
        {
            if (string.IsNullOrEmpty(name) && name.Length <= 2)
                throw new Exception("لطفا نام محصول را به صورت صحیح وارد نمایید.");

            if (string.IsNullOrEmpty(barcode))
                throw new Exception("لطفا بارکد را به صورت صحیح وارد نمایید.");

            if (string.IsNullOrEmpty(description) && description.Length <= 2)
                throw new Exception("لطفا توضیحات محصول را به صورت صحیح وارد نمایید.");

            if (price == default)
                throw new Exception("لطفا قیمت را به صورت صحیح وارد نمایید.");

            return new Product { Name = name, Description = description, Price = price };
        }
    }
}
