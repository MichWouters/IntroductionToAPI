using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFirstApi.DTO;
using MyFirstApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFirstApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]

    public class UsersController : ControllerBase
    {
        private IAppUserService _service;

        public UsersController(IAppUserService service)
        {
            // Dependency Injection
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetAsync()
        {
            var result = await _service.GetUsers();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUserAsync(int id)
        {
            var result = await _service.GetUser(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> AddUserAsync(AppUser user)
        {
            await _service.AddUser(user);
            return Created("", null);
        }

        [HttpGet("Member/{id}")]
        public async Task<ActionResult<MemberDto>> GetMemberAsync(int id)
        {
            MemberDto member = await _service.GetMemberAsync(id);
            return Ok(member);
        }
    }
}