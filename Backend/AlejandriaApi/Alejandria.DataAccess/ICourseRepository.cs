using Alejandria.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace Alejandria.DataAccess
{
    public interface ICourseRepository
    {
        ICollection<User> GetCollection(string filter);

        User GetItem(int id);

        void Create(User entity);

        void Update(User entity);

        void Delete(int id);
    }
}
