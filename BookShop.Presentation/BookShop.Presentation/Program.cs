using BookShop.Domain.Models;
using BookShop.Infrastructure.Repositories;

namespace BookShop.Presentation
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //BaseRepository baseRepository = new();
            UserRepository userRepository = new UserRepository();
            //IEnumerable<User> users = new List<User>()
            //{
            //   new(){Name = "Abbos", Email ="Gulomov", Password="2112"},
            //   new(){Name = "Salom", Email ="Sheraliyev", Password="asadsa"},
            //};


            //await userRepository.AddRangeAsync(users);
             await userRepository.GetByIdAsync(3);
            Console.ReadKey();
            
        }
    }
}