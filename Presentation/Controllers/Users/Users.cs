using Domain.Dto.Requests;
using Domain.Dto.Responses;
using Domain.Models;
using Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace sist_gestion_backend.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class Users(IUserRepository repository) : ControllerBase
    {
        private readonly IUserRepository _repository = repository;

        // GET: api/<Users>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var users = await _repository.GetUsers();
                var response = new GetAllResponseDto<User>
                {
                    Success = true,
                    Data = users,
                    Total = users.Count(),
                    Page = 1,
                }; 
                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // GET api/<Users>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Users>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserDto user)
        {
            try
            {
                var createdUser = await _repository.CreateUser(user);
                var response = new CreateResponseDto<User>
                {
                    Success = true,
                    Data = createdUser,
                };
                return Ok(response);
                
            }catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // PUT api/<Users>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Users>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
