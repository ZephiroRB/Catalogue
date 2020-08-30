using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalogue.Core.Entities;
using Catalogue.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalogue.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _UserRepository;

        public UsersController(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;

        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _UserRepository.GetUsers();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _UserRepository.GetUser(id);

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> addUser(User user)
        {
            await _UserRepository.addUser(user);

            return Ok(user);
        }
    }
}
