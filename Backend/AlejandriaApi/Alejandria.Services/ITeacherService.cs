using Alejandria.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alejandria.Services
{
    public interface ITeacherService
    {
        Task<ICollection<TeacherDto>> GetCollection(string filter);

        Task<ResponseDto<TeacherDto>> GetTeacher(int id);

        Task Create(TeacherDto entity);

        Task Update(int id, TeacherDto entity);

        Task Delete(int id);
    }
}
