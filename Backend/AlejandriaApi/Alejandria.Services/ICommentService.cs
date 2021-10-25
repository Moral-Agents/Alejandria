using Alejandria.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alejandria.Services
{
    public interface ICommentService
    {
        Task<ICollection<CommentDto>> GetCollection();
        Task<ResponseDto<CommentDto>> GetComment(int id);
        Task Create(CommentDto request);
        Task Update(int id, CommentDto request);
        Task Delete(int id);

        Task<ICollection<CommentDto>> GetCollection(int id);
    }
}
