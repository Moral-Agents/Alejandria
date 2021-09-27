using Alejandria.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace Alejandria.DataAccess
{
    public interface ICourseRepository
    {
        ICollection<Course> GetCollection(string filter);

        Course GetItem(int id);

        void Create(Course entity);

        void Update(Course entity);

        void Delete(int id);
    }
}
