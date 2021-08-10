using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1.Models.Entities;

namespace Task1.Services.UserService
{
    public class UserService : IUserService
    {
        private List<User> _users = new List<User>
        {
            new User { Id = 1, FullName = "Bat Man", Username = "BatMan123", Password = "heLOgen92",  GroupName="Avenger", Age=23 }
        };
        public async Task<User> Authenticate(string username, string password)
        {
            var user = await Task.Run(() => _users.SingleOrDefault(x => x.Username == username && x.Password == password));

            if (user == null)
                return null;

            return user;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await Task.Run(() => _users);
        }
    }
}
