using CursoArquitecturaNet.Core.Entities;
using CursoArquitecturaNet.Core.Repository.Base;

namespace CursoArquitecturaNet.Core.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductByNameAsync(string productName);
    }
}