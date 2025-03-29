using Domain.Dto.Requests;
using Domain.Exceptions;
using Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace sist_gestion_backend.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class Auth(IAuthRepository _repository) : ControllerBase
    {
        private IActionResult HandleErrors(dynamic error)
        {
            if (error is CustomException customException)
            {
                var problemDetails = new ProblemDetails
                {
                    Title = "Custom Error",
                    Status = customException.StatusCode, 
                    Detail = customException.Message
                };
                return BadRequest(problemDetails);
            }
            else if (error is Exception ex)
            {
                var problemDetails = new ProblemDetails
                {
                    Title = "Internal Server Error",
                    Status = StatusCodes.Status500InternalServerError,
                    Detail = "An unexpected error occurred. Please try again later."
                };
                
                Console.WriteLine(ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, problemDetails);
            }
    
            return BadRequest("An unknown error occurred.");
        }

        
        // POST api/<controller>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                //TODO: Implementar JWT
                var user = await _repository.Login(loginDto);
                return Ok(user);
                
            }catch(Exception ex)
            {
                return HandleErrors(ex);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserDto registerDto)
        {
            try { 
                //TODO: Implementar JWT
                var newUser = await _repository.Register(registerDto);
                return Ok(newUser);
            }
            catch (Exception ex)
            {
                return HandleErrors(ex);
            }
        }
    }
}
