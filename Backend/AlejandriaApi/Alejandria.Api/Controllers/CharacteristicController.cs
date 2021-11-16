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
    public class CharacteristicController : ControllerBase
    {
        private readonly ICharacteristicService _service;

        public CharacteristicController(ICharacteristicService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task Create([FromBody] CharacteristicDto request)
        {
            await _service.Create(request);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ResponseDto<CharacteristicDto>> Get(int id)
        {
            return await _service.GetCharacteristic(id);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task Delete(int id)
        {
            await _service.Delete(id);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task Update(int id, [FromBody] CharacteristicDto request)
        {
            await _service.Update(id, request);
        }
    }
}
