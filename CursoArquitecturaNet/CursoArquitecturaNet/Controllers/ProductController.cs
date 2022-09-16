using AutoMapper;
using CursoArquitecturaNet.Application.Interfaces;
using CursoArquitecturaNet.Core.Entities;
using CursoArquitecturaNet.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CursoArquitecturaNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet("GetProductByname/{productName}")]
        public async Task<IEnumerable<ProductDto>> GetProducts(string productName)
        {
            if (string.IsNullOrEmpty(productName))
            {
                var list = await _productService.GetProductList();
                var mapped = _mapper.Map<IEnumerable<ProductDto>>(list);
                return mapped;
            }

            var listByName = await _productService.GetProductByName(productName);
            var mappedByName = _mapper.Map<IEnumerable<ProductDto>>(listByName);
            return mappedByName;
        }

        [HttpGet("GetProductById/{productId}")]
        public async Task<ProductDto> GetProductById(int productId)
        {
            var product = await _productService.GetProductById(productId);
            var mapped = _mapper.Map<ProductDto>(product);
            return mapped;
        }

        [HttpPost]
        public async Task<ProductDto> CreateProduct(ProductDto productViewModel)
        {
            var mapped = _mapper.Map<Product>(productViewModel);
            if (mapped == null)
                throw new Exception($"Entity culd not be mapped.");

            var entityDto = await _productService.Create(mapped);
            var mappedViewModel = _mapper.Map<ProductDto>(entityDto);
            return mappedViewModel;
        }

        [HttpPut]
        public async Task UpdateProduct(ProductDto productViewModel)
        {
            var mapped = _mapper.Map<Product>(productViewModel);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");

            await _productService.Update(mapped);
        }

        [HttpDelete]
        public async Task DeleteProduct(ProductDto productVieModel)
        {
            var mapped = _mapper.Map<Product>(productVieModel);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");

            await _productService.Delete(mapped);
        }

    }
}
