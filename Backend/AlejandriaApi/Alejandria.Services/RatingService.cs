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
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _repository;
        public RatingService(IRatingRepository repository)
        {
            _repository = repository;
        }
  

        public async Task Create(RatingDto request)
        {
            try
            {
                await _repository.Create(new Rating
                {
                    Score = request.Score,
                    UserId = request.UserId,
                    CourseId = request.CourseId
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

        public async Task<ICollection<RatingDto>> GetCollection()
        {
            var collection = await _repository.GetCollection();

            return collection.
                Select(p => new RatingDto
                {
                    Id = p.Id,
                    Score = p.Score,
                    CourseId = p.CourseId,
                    UserId = p.UserId
                })
                .ToList();
        }

        public async Task<ResponseDto<RatingDto>> GetRating(int id)
        {
            var response = new ResponseDto<RatingDto>();
            var rating = await _repository.GetItem(id);

            if (rating == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new RatingDto
            {
                Id = rating.Id,
                Score = rating.Score,
                CourseId = rating.CourseId,
                UserId = rating.UserId
            };

            response.Success = true;

            return response;
        }

        public async Task Update(int id, RatingDto request)
        {
            var response = await _repository.GetItem(id);

            if (response != null)
            {
                response.Score = request.Score;

                await _repository.Update(response);
            }
        }
    }
}
