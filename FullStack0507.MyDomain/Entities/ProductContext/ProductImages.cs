using System;
using System.Collections.Generic;
using System.Text;

namespace FullStack0507.MyDomain.Entities.ProductContext;

public class ProductImages
{
    public int Id { get; set; }
    public string ObjectStorageUrl { get; set; }
    public bool IsMain { get; set; }
    public DateTime UploadedAt { get; set; }

    public Product Product { get; set; }
}
