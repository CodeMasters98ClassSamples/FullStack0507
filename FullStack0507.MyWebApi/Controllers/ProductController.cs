using Microsoft.AspNetCore.Mvc;

namespace FullStack0507.MyWebApi.Controllers;

//https://localhost:7004/Product/AddProduct
//DRY => Naming
[ApiController]
[Route("[controller]/[action]")]
public class ProductController : ControllerBase
{
    //Method => action , service , api
    [HttpPost]
    public string AddProduct(string description, string name)
    {
        return "";
    }

    [HttpGet]
    public string Get()
    {
        return "Product 1";
    }
}
