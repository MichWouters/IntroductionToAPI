﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFirstApi.DTO;
using MyFirstApi.Services;

namespace MyFirstApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController: ControllerBase
    {
        private IAppUserService _service;

        public UsersController(IAppUserService service)
        {
            // Dependency Injection
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<AppUser>> GetAsync()
        {
            return  await _service.GetUsers();
        }

        [HttpGet("{id}")]
        public async Task<AppUser> GetUserAsync(int id)
        {
            return await _service.GetUser(id);
        }

        [HttpPost]
        public async Task AddUserAsync(AppUser user)
        {
            await _service.AddUser(user);
        }

        [HttpGet("Members/{id}")]
        public async Task<ActionResult<MemberDto>> GetMemberAsync(int id)
        {
            MemberDto member = await _service.GetMemberAsync(id);
            return member;
        }

        [HttpGet("Members")]
        public async Task<ActionResult<ICollection<MemberDto>>> GetMembersAsync()
        {
            List<MemberDto> members = await _service.GetMembersAsync();
            return members;
        }
    }
}
