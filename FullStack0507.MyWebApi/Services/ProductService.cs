using FullStack0507.MyWebApi.Data;
using FullStack0507.MyWebApi.Intefaces;
using FullStack0507.MyWebApi.Models;
using System;

namespace FullStack0507.MyWebApi.Services;

public class ProductService : IProductService
{
    private readonly AppDbContext _appDbContext;

    public ProductService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public int Add(Product product)
    {
        //object
        //Work with Database

        //Sql Server
        _appDbContext.Set<Product>().Add(product);
        _appDbContext.SaveChanges();


        //Oracel

        return product.Id;
    }
    
    public bool Delete(int id)
    {
        var product = _appDbContext.Products.FirstOrDefault(x => x.Id == id);
        if (product is null)
            return false;

        return true;
    }

    public List<Product> GetAll(int id)
    {
        var products = _appDbContext.Products.ToList();
        return products;
    }

    public List<Product> GetAll()
    {
        throw new NotImplementedException();
    }

    public Product? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Product GetProductById(int id)
    {
        var product = _appDbContext.Products.FirstOrDefault(x => x.Id == id);
        return product;
    }



    public bool Update(Product product)
    {
        var productFromDb = _appDbContext.Products.FirstOrDefault(x => x.Id == product.Id);
        if (product is null)
            return false;

        productFromDb.Price = product.Price;
        productFromDb.Description = product.Description;
        productFromDb.Name = product.Name;
        productFromDb.Barcode = product.Barcode;
        _appDbContext.SaveChanges();

        return true;


    }
}
