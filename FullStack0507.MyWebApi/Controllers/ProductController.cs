using FullStack0507.MyWebApi.Dtos;
using FullStack0507.MyWebApi.Intefaces;
using FullStack0507.MyWebApi.Models;
using FullStack0507.MyWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FullStack0507.MyWebApi.Controllers;


//bueatifull url
//https://localhost:7004/Product/AddProduct
//DRY => Naming
[ApiController]
[Route("[controller]/[action]")]
public class ProductController : ControllerBase
{
    //Design Pattern -> Resuable code
    //Dependancy Injection -> Pattern
    private IProductService _productService;
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    //Best practise
    //Method => action , service , api
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddProductRequest dto)
    {
        //SaveData -> Data Application (Database, cache , file , .. , queue)

        //Map Dto -> Model
        //Extension method, Package -> mapster , automapper
        Product product = new Product()
        {
            Price = dto.price,
            Description = dto.description,
            Name = dto.name,
        };
        int result = _productService.AddProduct(product);

        //Work with Database

        return Ok(new AddProductResponse()
        {
            Id = result,
        });
    }

    [HttpPut]
    public string Update(string description, string name)
    {
        Product product = new Product()
        {
            Price = 100000,
            Description = description,
            Name = name,
        };
        return "";
    }


    [HttpGet]
    public string GetById(int id)
    {
        return "Product 1";
    }

    [HttpGet]
    public string GetAll()
    {
        return "Product 1";
    }
}
