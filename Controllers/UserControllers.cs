using AutoMapper;
using FinancesServer.Data.Users;
using FinancesServer.DTOs.Users;
using FinancesServer.Models.Shared;
using Microsoft.AspNetCore.Mvc;

namespace FinancesServer.Controllers
{
    [Route("/api/income")]
    [ApiController]
    public class UserControllers : ControllerBase
    {
        private readonly IUserRepo _repo;
        private readonly IMapper _mapper;

        public UserControllers(IUserRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserReadDto>>> GetAllUsers()
        {
            var allUsers = await _repo.GetAllUsers();

            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(allUsers));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var userModel = await _repo.GetUserById(id);
            if(userModel == null)
            {
                return NotFound();
            }
            _repo.DeleteUser(userModel);
            await _repo.SaveChanges();

            return NoContent();
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<ActionResult<UserReadDto>> GetUserById(int id)
        {
            var userModel = await _repo.GetUserById(id);
            if (userModel != null)
            {
                return Ok(_mapper.Map<UserReadDto>(userModel));
            }
            return NotFound();
        }


        [HttpPost]
        public async Task<ActionResult<UserReadDto>> CreateUser(UserCreateDto userCreateDto)
        {
            var userModel = _mapper.Map<User>(userCreateDto);
            await _repo.CreateUser(userModel);
            await _repo.SaveChanges();

            var userReadDto = _mapper.Map<UserReadDto>(userModel);
            
            
            return CreatedAtRoute(nameof(GetUserById), new { Id = userReadDto.Id}, userReadDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, UserUpdateDto userUpdateDto)
        {
            var userModel = await _repo.GetUserById(id);
            if(userModel == null)
            {
                return NotFound();
            }
            _mapper.Map(userUpdateDto, userModel);

            await _repo.SaveChanges();

            return NoContent();
        }
    }
}