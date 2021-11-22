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
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _repository;

        public AnswerService(IAnswerRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(AnswerDto request)
        {
            try
            {
                await _repository.Create(new Answer
                {
                    Description = request.Description,
                    CommentId = request.CommentId,
                    DateTime = DateTime.Now
                });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<ResponseDto<AnswerDto>> GetAnswer(int id)
        {
            var response = new ResponseDto<AnswerDto>();
            var answer = await _repository.GetItem(id);

            if (answer == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new AnswerDto
            {
                Id = answer.Id,
                Description = answer.Description,
                CommentId = answer.CommentId,
                DateTime = answer.DateTime
            };

            response.Success = true;

            return response;
        }

        public async Task<ICollection<AnswerDto>> GetCollection()
        {
            var collection = await _repository.GetCollection();

            return collection.
                Select(p => new AnswerDto
                {
                    Id = p.Id,
                    Description = p.Description,
                    CommentId = p.CommentId,
                    DateTime = p.DateTime
                })
                .ToList();
        }

        public async Task Update(int id, AnswerDto request)
        {
            var answer = await _repository.GetItem(id);

            if (answer != null)
            {
                answer.Description = request.Description;
                answer.DateTime = DateTime.Now;

                await _repository.Update(answer);
            }
        }
    }
}
