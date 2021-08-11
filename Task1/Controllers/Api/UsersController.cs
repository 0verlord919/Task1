using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1.Models.DTOs;
using Task1.Models.Entities;
using Task1.Services.CacheService;
using Task1.Services.Hubs;

namespace Task1.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMemoryCacheService _cacher;
        private readonly IHubContext<SignalRHub> _hubContext;
        public UsersController(IMemoryCacheService cacher, IHubContext<SignalRHub> hubContext)
        {
            _cacher = cacher;
            _hubContext = hubContext;
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetUsers()
        {
            IEnumerable<User> users = new List<User>();
            users = _cacher.GetCache<User>("Users");
            List<UserResponseDTO> userList = new List<UserResponseDTO>();
            if (users is not null)
            {
                foreach (var item in users)
                {
                    UserResponseDTO userResponseDTO = new UserResponseDTO();
                    if (item.GroupName.ToUpper() == "AVENGER")
                    {
                        userResponseDTO.FullName = item.FullName;
                        userResponseDTO.GroupName = item.GroupName;
                        userResponseDTO.Age = item.Age;
                        userList.Add(userResponseDTO);
                    }
                }
            }
            return new OkObjectResult(userList);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddUser([FromBody] AddUserDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IEnumerable<User> users = new List<User>();
            users = _cacher.GetCache<User>("Users");
            var userList = new List<User>();
            if (users is not null)
            {
                userList = users.Where(x => x.GroupName.ToUpper() == "AVENGER").ToList();
            }

            var newUser = new User();
            newUser.FullName = user.FullName;
            newUser.GroupName = user.GroupName;
            newUser.Age = user.Age ?? 0;
            userList.Add(newUser);
            _cacher.SetCache<User>("Users", userList);

            if (user.GroupName.ToUpper() == "AVENGER")
            {
                await _hubContext.Clients.All.SendAsync("AddUser", user);
            }

            return CreatedAtAction(nameof(GetUsers), user);
        }
    }
}
