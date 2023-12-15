using Microsoft.AspNetCore.Mvc;
using Trabalho_API_Produto.Contracts.Repository;
using Trabalho_API_Produto.Repository;

namespace Trabalho_API_Produto.Controllers
{
    [ApiController]
    [Route("store")]
    public class StoreController : ControllerBase
    {
        private readonly IStoreRepository _storeRepository;

        public StoreController(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _storeRepository.Get());
        }
    }
}
