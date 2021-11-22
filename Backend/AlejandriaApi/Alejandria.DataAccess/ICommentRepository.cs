using Alejandria.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alejandria.DataAccess
{
    public interface ICommentRepository
    {
        Task<ICollection<Comment>> GetCollection();
        Task<ICollection<Comment>> GetCollectionByTeacherId(int TeacherId);
        Task<Comment> GetItem(int id);
        Task Create(Comment entity);
        Task Update(Comment entity);
        Task Delete(int id);
    }
}
