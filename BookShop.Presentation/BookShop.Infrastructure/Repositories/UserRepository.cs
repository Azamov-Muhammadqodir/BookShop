using BookShop.Application.Interfaces.RepositoryInterfaces;
using BookShop.Domain.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public async Task AddAsync(User user)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(conString()))
            {
                string query = "insert into public.user(name, email, password)" +
                                "values(@name, @email, @password)";

                connection.Open();
                NpgsqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@name", user.Name);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@password", user.Password);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public async Task AddRangeAsync(IEnumerable<User> users)
        {
            foreach(var user in users)
            {
                await AddAsync(user);
            }
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            User user = new() { Name = "", Email = "", Password = ""};
            using NpgsqlConnection connection = new(conString());
                connection.Open();
                NpgsqlCommand command = new("select * from public.user where id = @id");
                var s = command.Parameters.AddWithValue("@id", id);
                NpgsqlDataReader reader = await command.ExecuteReaderAsync();
                while(reader.Read())
                {
                    user = new()
                    {
                        Id = (int)reader["id"],
                        Name = reader["name"].ToString()!,
                        Email = reader["email"].ToString()!,
                        Password = reader["password"].ToString()!
                    };
                }
                connection.Close();

             return user!;
        }

        public async Task<bool> UpdateAsync(User entity)
        {
            using(NpgsqlConnection connection = new(conString()))
            {
                connection.Open();
                NpgsqlCommand cmd = new("update user set name=@name, email = @email, password=@password" +
                                        " where id=@id");

            }
        }
    }
}
