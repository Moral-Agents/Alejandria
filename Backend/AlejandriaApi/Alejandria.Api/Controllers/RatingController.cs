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
    public class RatingController : ControllerBase 
    {
        private readonly IRatingService _service;

        public RatingController(IRatingService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<RatingDto>> List()
        {
            return await _service.GetCollection();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ResponseDto<RatingDto>> Get(int id)
        {
            return await _service.GetRating(id);
        }

        [HttpPost]
        public async Task Post([FromBody] RatingDto request)
        {
            await _service.Create(request);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task Delete(int id)
        {
            await _service.Delete(id);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task Update(int id, [FromBody] RatingDto request)
        {
            await _service.Update(id, request);
        }

        [HttpGet]
        [Route("courses/{courseId:int}")]
        public async Task<IEnumerable<RatingDto>> List(int courseId)
        {
            return await _service.GetCollection(courseId);
        }
    }
}
