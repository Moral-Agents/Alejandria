using Alejandria.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alejandria.DataAccess
{
    public interface IUserRepository
    {
        Task<ICollection<User>> GetCollection(string filter);

        Task<ICollection<User>> GetCollectionE(string email, string pwd);

        Task<User> GetItem(int id);

        Task Create(User entity);

        Task Update(User entity);

        Task Delete(int id);
    }
}
