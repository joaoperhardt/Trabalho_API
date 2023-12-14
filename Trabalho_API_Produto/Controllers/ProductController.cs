using Microsoft.AspNetCore.Mvc;
using Trabalho_API_Produto.Contracts.Repository;
using Trabalho_API_Produto.DTO;
using Trabalho_API_Produto.Entity;

namespace Trabalho_API_Produto.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductDTO product)
        {
            await _productRepository.Add(product);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _productRepository.Get());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _productRepository.GetById(id));
        }

        [HttpGet("ByName/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            return Ok(await _productRepository.GetByName(name));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductEntity product)
        {
            await _productRepository.Update(product);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _productRepository.Delete(id);
            return Ok();
        }
    }
}
