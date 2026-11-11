namespace FullStack0507.MyDomain.Entities.ProductContext;

/// <summary>
/// Modeling
/// Class -> Properties , Methods
/// </summary>
public class Product
{
    public int Id { get; private set; }
    public string Name { get;  private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; } //decimal -> value object price
    public string Barcode { get; private set; }
    public List<ProductImages> Images { get; set; }
    public List<ProductAttributes> Attributes { get; set; }

    public void Update()
    {
        //Update
    }

    public static Product Add(string name, string description, decimal price, string barcode)
    {
        if (string.IsNullOrEmpty(name) && name.Length <= 2)
            throw new Exception("لطفا نام محصول را به صورت صحیح وارد نمایید.");

        if (string.IsNullOrEmpty(barcode))
            throw new Exception("لطفا بارکد را به صورت صحیح وارد نمایید.");

        if (string.IsNullOrEmpty(description) && description.Length <= 2)
            throw new Exception("لطفا توضیحات محصول را به صورت صحیح وارد نمایید.");

        if (price == default)
            throw new Exception("لطفا قیمت را به صورت صحیح وارد نمایید.");

        if (!barcode.StartsWith("TRE"))
        {
            throw new Exception("لطفا قیمت را به صورت صحیح وارد نمایید.");
        }

        return new Product { Name = name, Description = description, Price = price };
    }
}
