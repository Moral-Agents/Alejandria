using Alejandria.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alejandria.DataAccess
{
    public interface ICourseRepository
    {
        Task<ICollection<Course>> GetCollection(string filter);

        Task<Course> GetItem(int id);

        Task Create(Course entity);

        Task Update(Course entity);

        Task Delete(int id);
    }
}
