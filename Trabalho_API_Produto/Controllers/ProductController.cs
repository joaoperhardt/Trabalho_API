using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "admin,storekeeper")]
        public async Task<IActionResult> Add(ProductDTO product)
        {
            await _productRepository.Add(product);
            return Ok();
        }

        [HttpGet]
        [Authorize(Roles = "admin,storekeeper")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _productRepository.Get());
        }

        [HttpGet("byidproduct/{id}", Name = "GetByIdProduct")]
        [Authorize(Roles = "admin,storekeeper")]
        public async Task<IActionResult> GetByIdProduct(int id)
        {
            return Ok(await _productRepository.GetById(id));
        }

        [HttpGet("bynameproduct/{name}", Name = "GetByNameProduct")]
        public async Task<IActionResult> GetByNameProduct(string name)
        {
            return Ok(await _productRepository.GetByName(name));
        }

        [HttpPut]
        [Authorize(Roles = "admin,storekeeper")]
        public async Task<IActionResult> Update(ProductEntity product)
        {
            await _productRepository.Update(product);
            return Ok();
        }

        [HttpDelete]
        [Authorize(Roles = "admin,storekeeper")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productRepository.Delete(id);
            return Ok();
        }
    }
}
