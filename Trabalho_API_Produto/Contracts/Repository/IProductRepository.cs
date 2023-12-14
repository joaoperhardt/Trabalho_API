using Trabalho_API_Produto.DTO;
using Trabalho_API_Produto.Entity;

namespace Trabalho_API_Produto.Contracts.Repository
{
    public interface IProductRepository
    {
        Task Add(ProductDTO product);
        Task<IEnumerable<ProductEntity>> Get();
        Task Update(ProductEntity product);
        Task Delete(int id);
        Task<ProductEntity> GetById(int id);
        Task<ProductEntity> GetByName(string name);
    }
}
