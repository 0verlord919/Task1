using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Task1.Models.DTOs;

namespace Task1.Services.Hubs
{
    public class SignalRHub : Hub
    {
        public async Task AddUserAsync(UserResponseDTO user)
        {
            await Clients.All.SendAsync("AddUser", user);
        }
    }
}