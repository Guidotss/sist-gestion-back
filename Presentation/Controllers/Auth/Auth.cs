using Domain.Dto.Requests;
using Domain.Dto.Requests.Auth;
using Domain.Dto.Responses;
using Domain.Exceptions;
using Domain.Repositories;
using Domain.Services;
using Domain.UseCases;
using Domain.UseCases.Implementations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace sist_gestion_backend.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class Auth(IMediator _mediator) : ControllerBase
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
                var response = await _mediator.Send(new LoginRequest(loginDto)); 
                return Ok(response); 
            }catch(Exception ex)
            {
                return HandleErrors(ex);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserDto registerDto)
        {
            try
            {
                var response = await _mediator.Send(new RegisterRequest(registerDto));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return HandleErrors(ex);
            }
        }
    }
}
