﻿using Dapper;
using Trabalho_API_Produto.Contracts.Repository;
using Trabalho_API_Produto.DTO;
using Trabalho_API_Produto.Entity;
using Trabalho_API_Produto.Infrastructure;

namespace Trabalho_API_Produto.Repository
{
    public class UserRepository : Connection, IUserRepository
    {
        public async Task Add(UserDTO user)
        {
            string sql = "INSERT INTO USER (Name, Email, Password, Role) VALUE (@Name, @Email, @Password, @Role)";

            await Execute(sql, user);
        }

        public async Task Delete(int id)
        {
            string sql = "DELETE FROM USER WHERE Id = @id";
            await Execute(sql, new { id });
        }

        public async Task<IEnumerable<UserEntity>> Get()
        {
            string sql = "SELECT * FROM USER";
            return await GetConnection().QueryAsync<UserEntity>(sql);
        }

        public async Task Update(UserEntity user)
        {
            string sql = @"
                UPDATE USER SET 
                Name = @Name, 
                Email = @Email, 
                Password = @Password,
                Role = @Role
                WHERE Id = @Id";

            await Execute(sql, user);
        }

        public async Task<UserTokenDTO> Login(UserLoginDTO user)
        {
            string sql = "SELECT * FROM user WHERE Email = @Email AND Password = @Password";
            UserEntity userLogin = await GetConnection().QueryFirstAsync<UserEntity>(sql, user);
            return new UserTokenDTO
            {
                Token = Authentication.GenerateToken(userLogin)
            };
        }
    }
}
