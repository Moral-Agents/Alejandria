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
        private readonly IUserRepository _repository1;

        public CommentService(ICommentRepository repository, IUserRepository repository1)
        {
            _repository = repository;
            _repository1 = repository1;
        }

        public async Task Create(CommentDto request)
        {
            var user = await _repository1.GetItem(request.UserId);

            try
            {
                await _repository.Create(new Comment
                {
                    Description = request.Description,
                    TeacherId = request.TeacherId,
                    UserId = request.UserId,
                    Name = user.Name,
                    DateTime = DateTime.Now
                });
            }
            catch(Exception ex)
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
                    TeacherId = p.TeacherId,
                    UserId = p.UserId,
                    Name = p.Name,
                    DateTime = p.DateTime
                })
                .ToList();
        }

        public async Task<ICollection<CommentDto>> GetCollectionByTeacherId(int TeacherId)
        {
            var collection = await _repository.GetCollectionByTeacherId(TeacherId);

            return collection.
                Select(p => new CommentDto
                {
                    Id = p.Id,
                    Description = p.Description,
                    TeacherId = p.TeacherId,
                    UserId = p.UserId,
                    Name = p.Name,
                    DateTime = p.DateTime
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
                TeacherId = comment.TeacherId,
                UserId = comment.UserId,
                Name = comment.Name,
                DateTime = comment.DateTime
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
                comment.DateTime = DateTime.Now;

                await _repository.Update(comment);
            }
        }
    }
}
