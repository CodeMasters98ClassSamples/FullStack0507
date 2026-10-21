namespace FullStack0507.MyWebApi.Contracts;

public interface ICustomService<T> 
{
    int Add(T item);
    T? GetById(int id);
    List<T> GetAll();
    bool Update(T item);
    bool Delete(int id);
}
