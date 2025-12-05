using API.Data;
using API.DTOs;
using API.Interfaces;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    public class UsersController(IUserRepository userRepo) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDTO>>> GetUsers()
        {
            var users = await userRepo.GetMembersAsync();

            return Ok(users);
        }


        [HttpGet("{username}")] // api/users/{username}
        public async Task<ActionResult<MemberDTO>> GetUser(string username)
        {
            var user = await userRepo.GetMemberAsync(username);

            if (user == null) return NotFound();

            return user;
        }
    }
}
