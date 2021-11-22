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
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _service;

        public CommentController(ICommentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<CommentDto>> List()
        {
            return await _service.GetCollection();
        }

        [HttpGet]
        [Route("List/{TeacherId:int}")]
        public async Task<IEnumerable<CommentDto>> ListByTeacherId(int TeacherId)
        {
            return await _service.GetCollectionByTeacherId(TeacherId);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ResponseDto<CommentDto>> Get(int id)
        {
            return await _service.GetComment(id);
        }

        [HttpPost]
        public async Task Post([FromBody] CommentDto request)
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
        public async Task Update(int id, [FromBody] CommentDto request)
        {
            await _service.Update(id, request);
        }
    }
}
