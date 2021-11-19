using Alejandria.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alejandria.DataAccess
{
    public interface ITeacherRepository
    {
        Task<ICollection<Teacher>> GetCollection(string filter);

        Task<Teacher> GetItem(int id);

        Task Create(Teacher entity);

        Task Update(Teacher entity);

        Task Delete(int id);
    }
}
