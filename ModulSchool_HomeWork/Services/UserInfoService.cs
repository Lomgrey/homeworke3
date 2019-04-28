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
        public async Task<User> GetById(long id)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                return await connection.QuerySingleAsync<User>(
                    "SELECT * FROM sdemo.users3 where id = @id", new {id});
            }
        }

        public async Task<AddUserResult> AddNewUser(User user)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                var addedUserId = await connection.QuerySingleAsync<int>(
                    "insert into sdemo.users3 (email, nickname, phone) values (@email, @nickname, @phone) RETURNING id",
                    user
                );
                
                return new AddUserResult
                {
                    Status = "OK",
                    Message = "Added User Id = " + addedUserId
                };

                
            }
        }
    }
}