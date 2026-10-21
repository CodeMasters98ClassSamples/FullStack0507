using FullStack0507.MyWebApi.Contracts;
using FullStack0507.MyWebApi.Models;

namespace FullStack0507.MyWebApi.Intefaces;

public interface IProductService : ICustomService<Product>
{
    int Add(Product product);
    Product? GetById(int id);
    List<Product> GetAll();
    bool Update(Product item);
    bool Delete(int id);
}
