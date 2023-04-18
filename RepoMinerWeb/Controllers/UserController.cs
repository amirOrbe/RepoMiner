using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RepoMinerAnalysis.Data;
using RepoMinerWeb.Models.DTO;
using RepoMinerAnalysis.Models.Domain;
using RepoMinerWeb.Repositories;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace RepoMinerWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = userRepository.GetAll();

            var usersDto = mapper.Map<List<UserDto>>(users);

            return Ok(usersDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            {
                var user = userRepository.GetById(id);

                if (user == null) return NotFound();

                var userDto = mapper.Map<UserDto>(user);

                return Ok(userDto);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateUserDto userDto)
        {
            var user = mapper.Map<User>(userDto);

            user = userRepository.Create(user);

            return Ok(mapper.Map<UserDto>(user));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var user = userRepository.Delete(id);

            if (user == null) return NotFound();

            var userDto = mapper.Map<UserDto>(user);

            return Ok(userDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateUserDto updateUserDto)
        {
            var user = mapper.Map<User>(updateUserDto);

            user = userRepository.Update(id, user);

            if (user == null) return NotFound();

            var userDto = mapper.Map<UserDto>(user);

            return Ok(userDto);
        }

    }
}
