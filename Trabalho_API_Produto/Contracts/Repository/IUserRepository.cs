using Trabalho_API_Produto.DTO;
using Trabalho_API_Produto.Entity;

namespace Trabalho_API_Produto.Contracts.Repository
{
    public interface IUserRepository
    {
        Task Add(UserDTO user);
        Task<IEnumerable<UserEntity>> Get();
        Task Update(UserEntity user);
        Task Delete(int id);
    }
}
