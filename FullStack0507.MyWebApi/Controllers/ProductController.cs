using Asp.Versioning;
using FullStack0507.MyDomain.Entities.ProductContext;
using FullStack0507.MyWebApi.Dtos;
using FullStack0507.MyWebApi.Intefaces;
using FullStack0507.MySharedApplication.Wrappers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FullStack0507.MyWebApi.Controllers;


//bueatifull url
//https://localhost:7004/Product/AddProduct
//DRY => Naming
[ApiVersion(1)]
[ApiController]
[Route("v{v:apiVersion}/[controller]/[action]")]
public class ProductController : ControllerBase
{
    //Design Pattern -> Resuable code
    //Dependancy Injection -> Pattern
    private IProductService _productService;
    private ILogger<ProductController> _logger;
    public ProductController(IProductService productService, ILogger<ProductController> logger)
    {
        _productService = productService;
        _logger = logger;
    }

    //Best practise
    //Method => action , service , api
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddProductRequest dto)
    {
        _logger.LogDebug("ASKNDKLAD");

        //SaveData -> Data Application (Database, cache , file , .. , queue)

        if (dto.price <= 0)
        {
            return BadRequest(Result.Failure(Error.InValidPrice, status: HttpStatusCode.BadRequest));
        }

        //Map Dto -> Model
        //Extension method, Package -> mapster , automapper
        Product product = Product.Add(dto.name, dto.description, dto.price, dto.barcode);
        var result = Result.Success(_productService.Add(product));

        return Ok(result);
    }

    [HttpPut]
    public string Update(string description, string name)
    {
        //Product product = new Product()
        //{
        //    Price = 100000,
        //    Description = description,
        //    Name = name,
        //};
        //bool result = _productService.Update(product);

        return "";
    }

    [HttpGet]
    public async Task<IActionResult> GetById(int id)
    {
        Product? result = _productService.GetById(id);
        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<Product> result = _productService.GetAll();
        return Ok(result);
    }
}
