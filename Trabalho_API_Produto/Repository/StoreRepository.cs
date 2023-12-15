using Dapper;
using Trabalho_API_Produto.Contracts.Repository;
using Trabalho_API_Produto.Entity;
using Trabalho_API_Produto.Infrastructure;

namespace Trabalho_API_Produto.Repository
{
    public class StoreRepository : Connection, IStoreRepository
    {
        public async Task<IEnumerable<StoreEntity>> Get()
        {
            string sql = "SELECT * FROM STORE";
            return await GetConnection().QueryAsync<StoreEntity>(sql);
        }
    }
}
