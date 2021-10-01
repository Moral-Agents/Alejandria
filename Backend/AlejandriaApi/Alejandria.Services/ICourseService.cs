using Alejandria.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alejandria.Services
{
    public interface ICourseService
    {
        Task<ICollection<CourseDto>> GetCollection(string filter);

        Task<ResponseDto<CourseDto>> GetCourse(int id);

        Task Create(CourseDto request);

        Task Update(int id, CourseDto request);

        Task Delete(int id);
    }
}
