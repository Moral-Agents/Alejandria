using Alejandria.DataAccess;
using Alejandria.Dtos;
using Alejandria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alejandria.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _repository;

        public CommentService(ICommentRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(CommentDto request)
        {
            try
            {
                await _repository.Create(new Comment
                {
                    Description = request.Description,
                    UserId = request.UserId,
                    CourseId = request.CourseId
                });
            }catch(Exception ex)
            {
                throw;
            }
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<ICollection<CommentDto>> GetCollection()
        {
            var collection = await _repository.GetCollection();

            return collection.
                Select(p => new CommentDto
                {
                    Id = p.Id,
                    Description = p.Description,
                    CourseId = p.CourseId,
                    UserId = p.UserId
                })
                .ToList();
        }

        public async Task<ResponseDto<CommentDto>> GetComment(int id)
        {
            var response = new ResponseDto<CommentDto>();
            var comment = await _repository.GetItem(id);

            if (comment == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new CommentDto
            {
                Id = comment.Id,
                Description = comment.Description,
                CourseId = comment.CourseId,
                UserId = comment.UserId
            };

            response.Success = true;

            return response;
        }

        public async Task Update(int id, CommentDto request)
        {
            var comment = await _repository.GetItem(id);

            if (comment != null)
            {
                comment.Description = request.Description;

                await _repository.Update(comment);
            }
        }
    }
}
