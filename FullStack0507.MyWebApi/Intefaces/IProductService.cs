using FullStack0507.MyWebApi.Models;

namespace FullStack0507.MyWebApi.Intefaces
{
    public interface IProductService
    {
        int AddProduct(Product product);
        Product? GetProductById(int id);
        List<Product> GetAll();
        bool Update(Product product);
        bool Delete(int id);
    }
}
