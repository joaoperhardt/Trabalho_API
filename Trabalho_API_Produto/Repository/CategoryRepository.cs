using Dapper;
using Trabalho_API_Produto.Contracts.Repository;
using Trabalho_API_Produto.Entity;
using Trabalho_API_Produto.Infrastructure;

namespace Trabalho_API_Produto.Repository
{
    public class CategoryRepository : Connection, ICategoryRepository
    {
        public async Task<IEnumerable<CategoryEntity>> Get()
        {
            string sql = "SELECT * FROM CATEGORY";
            return await GetConnection().QueryAsync<CategoryEntity>(sql);
        }
    }
}
