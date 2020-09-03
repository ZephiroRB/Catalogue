using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userRepository.GetUsers();

            /* With AutoMapper*/
            var usersDTO = _mapper.Map<IEnumerable<UserDTO>>(users);

            /*
            without AutoMapper
            var usersDTO = users.Select(u => new UserDTO
            {
                Id = u.Id,
                Username = u.Username,
                Token = u.Token,
                UpdatedAt = u.UpdatedAt,
                CreatedAt = u.CreatedAt
            });*/

            return Ok(usersDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(long id)
        {
            var user = await _userRepository.GetUser(id);

            /* With AutoMapper*/
            var userDTO = _mapper.Map<UserDTO>(user);

            /*
            without AutoMapper
            var userDTO = new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                Token = user.Token,
                UpdatedAt = user.UpdatedAt,
                CreatedAt = user.CreatedAt
            };*/

            return Ok(userDTO);
        }

        [HttpPost]
        public async Task<IActionResult> addUser(UserDTO userDTO)
        {
            /* With AutoMapper*/
            var user = _mapper.Map<User>(userDTO);

            /*
            without AutoMapper
            var user = new User
            {
                Username = userDTO.Username,
                Token = userDTO.Token,
                UpdatedAt = userDTO.UpdatedAt,
                CreatedAt = userDTO.CreatedAt
            };*/

            await _userRepository.addUser(user);
            return Ok(user);
        }


        [HttpPut]
        public async Task<IActionResult> updateUser(long id, UserDTO userDTO)
        {
            /* With AutoMapper*/
            var user = _mapper.Map<User>(userDTO);
            user.Id = id;
            /*
            without AutoMapper
            var user = new User
            {
                Id = id,
                Username = userDTO.Username,
                Token = userDTO.Token,
                UpdatedAt = userDTO.UpdatedAt,
                CreatedAt = userDTO.CreatedAt
            };*/

            await _userRepository.updateUser(user);
            return Ok(user);
        }


        [HttpDelete]
        public async Task<IActionResult> deleteUser(long id)
        {
            var result = await _userRepository.deleterUser(id);
            return Ok(result);
        }


    }
}
