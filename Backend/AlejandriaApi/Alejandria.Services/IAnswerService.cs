using Alejandria.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alejandria.Services
{
    public interface IAnswerService
    {
        Task<ICollection<AnswerDto>> GetCollection();
        Task<ResponseDto<AnswerDto>> GetAnswer(int id);
        Task Create(AnswerDto request);
        Task Update(int id, AnswerDto request);
        Task Delete(int id);
    }
}
