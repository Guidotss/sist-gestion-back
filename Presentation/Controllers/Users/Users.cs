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
    }
}
