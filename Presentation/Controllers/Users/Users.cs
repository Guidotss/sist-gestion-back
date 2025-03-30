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

        // GET api/<Users>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
