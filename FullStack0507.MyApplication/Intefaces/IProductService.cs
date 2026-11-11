using FullStack0507.MyApplication.Contracts;
using FullStack0507.MyDomain.Entities.ProductContext;

namespace FullStack0507.MyWebApi.Intefaces;

public interface IProductService : ICustomService<Product>
{
    int Add(Product product);
    Product? GetById(int id);
    List<Product> GetAll();
    bool Update(Product item);
    bool Delete(int id);
}
