using CursoArquitecturaNet.Core.Entities;

namespace CursoArquitecturaNet.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductList();
        Task<Product> GetProductById(int id);
        Task<IEnumerable<Product>> GetProductByName(string productName);
        Task<Product> Create(Product product);
        Task Update(Product product);
        Task Delete(Product product);
    }
}
