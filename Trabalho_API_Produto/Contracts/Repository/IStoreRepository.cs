using Trabalho_API_Produto.Entity;

namespace Trabalho_API_Produto.Contracts.Repository
{
    public interface IStoreRepository
    {
        Task<IEnumerable<StoreEntity>> Get();
    }
}
