using System;
using System.Collections.Generic;
using System.Text;

namespace FullStack0507.MyDomain.Entities.ProductContext;

public class ProductAttributes
{
    public int Id { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
    public DateTime CreatedAt { get; set; }

    public Product Product { get; set; }
}
