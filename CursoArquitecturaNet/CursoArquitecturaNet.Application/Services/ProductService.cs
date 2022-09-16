using CursoArquitecturaNet.Application.Interfaces;
using CursoArquitecturaNet.Core.Entities;
using CursoArquitecturaNet.Core.Repository;

namespace CursoArquitecturaNet.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetProductList()
        {
            var productList = await _productRepository.GetAlLAsync();
            return productList;
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return product;
        }

        public async Task<IEnumerable<Product>> GetProductByName(string productName)
        {
            var productList = await _productRepository.GetProductByNameAsync(productName);
            return productList;
        }

        public async Task<Product> Create(Product product)
        {
            await ValidateProductIfExist(product);

            var newEntity = await _productRepository.AddAsync(product);
            return newEntity;
        }

        public async Task Update(Product product)
        {
            ValidateProductIfNotExist(product);

            var editProduct = await _productRepository.GetByIdAsync(product.Id);
            if (editProduct == null)
                throw new ApplicationException($"Entity could not be loaded");

            editProduct.Id = product.Id;
            editProduct.ProductName = product.ProductName;
            editProduct.UnitPrice = product.UnitPrice;
            editProduct.UnitsInStock = product.UnitsInStock;
            editProduct.UnitsOnOrder = product.UnitsOnOrder;

            await _productRepository.UpdateAsync(editProduct);
        }

        public async Task Delete(Product product)
        {
            ValidateProductIfNotExist(product);

            var deleteProduct = await _productRepository.GetByIdAsync(product.Id);
            if (deleteProduct == null)
                throw new ApplicationException($"Entity could not be loaded.");
            await _productRepository.DeleteAsync(deleteProduct);
        }

        private async Task ValidateProductIfExist(Product product)
        {
            var existingEntity = await _productRepository.GetByIdAsync(product.Id);
            if (existingEntity != null)
                throw new ApplicationException($"{product.ToString()} with this id already exists");
        }

        private void ValidateProductIfNotExist(Product product)
        {
            var existingEntity = _productRepository.GetByIdAsync(product.Id);
            if (existingEntity == null)
                throw new ApplicationException($"{product.ToString()} with this id is not exists");
        }
    }
}