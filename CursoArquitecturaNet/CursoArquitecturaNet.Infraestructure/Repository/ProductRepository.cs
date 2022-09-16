using CursoArquitecturaNet.Core.Entities;
using CursoArquitecturaNet.Core.Repository;
using CursoArquitecturaNet.Infraestructure.Data;
using CursoArquitecturaNet.Infraestructure.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace CursoArquitecturaNet.Infraestructure.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        protected readonly CursoArquitecturaNetContext _dbContext;

        public ProductRepository(CursoArquitecturaNetContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> GetProductByNameAsync(string productName)
        {
            return await _dbContext.Products
                .Where(x => x.ProductName.Contains(productName))
                .ToListAsync();
        }
    }
}
