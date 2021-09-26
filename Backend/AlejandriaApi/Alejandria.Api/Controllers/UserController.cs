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
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<UserDto> GetUsers([FromQuery] string filter)
        {
            return _service.GetCollection(filter);
        }

        [HttpGet]
        [Route("{id:int}")]
        public UserDto Get(int id)
        {
            return _service.GetUser(id);
        }

        [HttpPost]
        public void Post ([FromBody] UserDto request)
        {
            _service.Create(request);
        }
    }
}
