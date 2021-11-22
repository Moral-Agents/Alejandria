using Alejandria.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alejandria.DataAccess
{
    public interface IAnswerRepository
    {
        Task<ICollection<Answer>> GetCollection();

        Task<Answer> GetItem(int id);

        Task Create(Answer entity);

        Task Update(Answer entity);

        Task Delete(int id);
    }
}
