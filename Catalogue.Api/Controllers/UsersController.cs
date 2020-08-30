using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalogue.Core.DTOs;
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
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userRepository.GetUsers();
            var usersDTO = users.Select(u => new UserDTO
            {
                Id = u.Id,
                Username = u.Username,
                Token = u.Token,
                UpdatedAt = u.UpdatedAt,
                CreatedAt = u.CreatedAt
            });

            return Ok(usersDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userRepository.GetUser(id);
            var userDTO = new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                Token = user.Token,
                UpdatedAt = user.UpdatedAt,
                CreatedAt = user.CreatedAt
            };

            return Ok(userDTO);
        }

        [HttpPost]
        public async Task<IActionResult> addUser(UserDTO userDTO)
        {
            var user = new User
            {
                Username = userDTO.Username,
                Token = userDTO.Token,
                UpdatedAt = userDTO.UpdatedAt,
                CreatedAt = userDTO.CreatedAt
            };

            await _userRepository.addUser(user);
            return Ok(user);
        }
    }
}
