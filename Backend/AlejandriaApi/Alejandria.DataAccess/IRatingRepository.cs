using Alejandria.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alejandria.DataAccess
{
    public interface IRatingRepository
    {
        Task<ICollection<Rating>> GetCollection();
        Task<ICollection<Rating>> GetCollectionByCourseId(int courseId);
        Task<Rating> GetItem(int id);
        Task Create(Rating entity);
        Task Update(Rating entity);
        Task Delete(int id);
    }
}
