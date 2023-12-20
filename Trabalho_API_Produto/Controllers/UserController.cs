using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trabalho_API_Produto.Contracts.Repository;
using Trabalho_API_Produto.DTO;
using Trabalho_API_Produto.Entity;

namespace Trabalho_API_Produto.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(UserDTO user)
        {
            await _userRepository.Add(user);
            return Ok();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            return Ok(await _userRepository.Get());
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Update(UserEntity user)
        {
            await _userRepository.Update(user);
            return Ok();
        }

        [HttpDelete]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userRepository.Delete(id);
            return Ok();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserLoginDTO user)
        {
            try
            {
                return Ok(await _userRepository.Login(user));
            }
            catch (Exception ex)
            {
                return Unauthorized("Usuário ou senha invalidos");
            }
        }
    }
}
