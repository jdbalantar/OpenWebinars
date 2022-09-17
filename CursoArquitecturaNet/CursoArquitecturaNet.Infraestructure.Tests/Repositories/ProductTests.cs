using CursoArquitecturaNet.Infraestructure.Data;
using CursoArquitecturaNet.Infraestructure.Repository;
using CursoArquitecturaNet.Infraestructure.Tests.Base;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace CursoArquitecturaNet.Infraestructure.Tests.Repositories
{
    public class ProductTests
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly ProductRepository _productRepository;
        private readonly CursoArquitecturaNetContext _cursoArquitecturaNetContext;
        private ProductBuilder ProductBuilder { get; } = new ProductBuilder();

        public ProductTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            var dbOptions = new DbContextOptionsBuilder<CursoArquitecturaNetContext>()
                .UseInMemoryDatabase(databaseName: "CursoTestingDB").Options;

            _cursoArquitecturaNetContext = new CursoArquitecturaNetContext(dbOptions);
            _productRepository = new ProductRepository(_cursoArquitecturaNetContext);

        }

        [Fact]
        public async Task Get_Product_By_Name()
        {
            var existingProduct = ProductBuilder.Build();
            _cursoArquitecturaNetContext.Products.Add(existingProduct);
            await _cursoArquitecturaNetContext.SaveChangesAsync();

            _testOutputHelper.WriteLine($"ProductName: {existingProduct.ProductName}");

            var productListFromRepo = await _productRepository.GetProductByNameAsync(existingProduct.ProductName);
            Assert.Equal(ProductBuilder.TestProductName, productListFromRepo.ToList().First().ProductName);
        }
    }
}
