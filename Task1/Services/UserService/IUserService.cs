using System.Collections.Generic;
using System.Threading.Tasks;
using Task1.Models.Entities;

namespace Task1.Services.UserService
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAll();
    }
}
