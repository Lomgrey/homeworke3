using System;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.SignalR;
using ModulSchool_HomeWork.Models;
using ModulSchool_HomeWork.Services.Interfaces;
using Npgsql;

namespace ModulSchool_HomeWork.Services
{
    public class UserInfoService : IUserInfoService
    {

        private const string ConnectionString = 
            "host=localhost;port=5432;database=postgres;username=postgres;password=1";
        public async Task<User> GetById(Guid id)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                return await connection.QuerySingleAsync<User>(
                    "SELECT * FROM sdemo.users where id = @id", new {id});
            }
        }

        public async Task AddNewUser(User user)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                const string query = "insert into sdemo.users3 (id, email, nickname, phone) values (@id, @email, @nickname, @phone)";

                await connection.QuerySingleAsync<User>(query, user);
            }
        }
    }
}