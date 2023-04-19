using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RepoMinerWeb.Models.DTO;
using RepoMinerAnalysis.Models.Domain;
using RepoMinerWeb.Repositories;
using RepoMinerCore.LibGit2Sharp;

namespace RepoMinerWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly ILogger<UserController> logger;

        public UserController(IUserRepository userRepository, IMapper mapper, ILogger<UserController> logger)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = userRepository.GetAll();

            var usersDto = mapper.Map<List<UserDto>>(users);
            var repository = new GetRepositoriesData();
            repository.GetRepositorieData("https://github.com/amirOrbe/medussa_studio");

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
