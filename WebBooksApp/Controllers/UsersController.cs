using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebBooksApp.Data.Repositories;
using WebBooksApp.ViewModels.Users;

namespace WebBooksApp.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUsersRepository _usersRepository;

        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [HttpGet("count")]
        public async Task<IActionResult> Count()
        {
            var count = await _usersRepository.CountAsync();
            return Ok(new { count });
        }

        [HttpGet("{email:minlength(6)}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var user = await _usersRepository.GetByEmail(email);
            return Ok(new
            {
                user = Mapper.Map<UserViewModel>(user)
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetByEmailQuery([FromQuery] string email)
        {
            var user = await _usersRepository.GetByEmail(email);
            return Ok(new
            {
                user = Mapper.Map<UserViewModel>(user)
            });
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] UserEditViewModel model)
        {
            var result = await _usersRepository.AddPolicyToUser(model.Email, "RolePermissionChange");

            return Ok(result);
        }
    }
}
