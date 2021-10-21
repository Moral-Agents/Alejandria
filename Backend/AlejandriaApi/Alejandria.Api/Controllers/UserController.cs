using Alejandria.Dtos;
using Alejandria.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alejandria.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task Create([FromBody] UserDto request)
        {
            await _service.Create(request);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ResponseDto<UserDto>> Get(int id)
        {
            return await _service.GetUser(id);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task Delete(int id)
        {
            await _service.Delete(id);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task Update(int id, [FromBody] UserDto request)
        {
            await _service.Update(id, request);
        }

        [HttpGet]
        public async Task<IEnumerable<UserDto>> List([FromQuery] string filter)
        {
            return await _service.GetCollection(filter);
        }
    }
}
