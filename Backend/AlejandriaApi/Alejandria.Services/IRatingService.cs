using Alejandria.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alejandria.Services
{
    public interface IRatingService
    {
        Task<ICollection<RatingDto>> GetCollection();
        Task<ResponseDto<RatingDto>> GetRating(int id);
        Task Create(RatingDto request);
        Task Update(int id, RatingDto request);
        Task Delete(int id);

        Task<ICollection<RatingDto>> GetCollection(int id);
    }
}
