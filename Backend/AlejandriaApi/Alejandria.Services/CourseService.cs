using Alejandria.DataAccess;
using Alejandria.Dtos;
using Alejandria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alejandria.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _repository;

        public CourseService(ICourseRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(CourseDto request)
        {
            try
            {
                await _repository.Create(new Course
                {
                    Name = request.Name,
                    TeacherName = request.TeacherName,
                    TeacherLink = request.TeacherLink,
                    TeacherCode = request.TeacherCode,
                    TeacherMessage = request.TeacherMessage
                });
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<ICollection<CourseDto>> GetCollection(string filter)
        {
            var collection = await _repository.GetCollection(filter ?? string.Empty);

            return collection.
                Select(p => new CourseDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    TeacherName = p.TeacherName,
                    TeacherLink = p.TeacherLink,
                    TeacherCode = p.TeacherCode,
                    TeacherMessage = p.TeacherMessage
                })
                .ToList();
        }

        public async Task<ResponseDto<CourseDto>> GetCourse(int id)
        {
            var response = new ResponseDto<CourseDto>();
            var course = await _repository.GetItem(id);

            if (course == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new CourseDto
            {
                Id = course.Id,
                Name = course.Name,
                TeacherName = course.TeacherName,
                TeacherLink = course.TeacherLink,
                TeacherCode = course.TeacherCode,
                TeacherMessage = course.TeacherMessage
            };

            response.Success = true;

            return response;
        }

        public async Task Update(int id, CourseDto request)
        {
            var course = await _repository.GetItem(id);

            if (course != null)
            {
                await _repository.Update(new Course
                {
                    Name = request.Name,
                    TeacherName = request.TeacherName,
                    TeacherLink = request.TeacherLink,
                    TeacherCode = request.TeacherCode,
                    TeacherMessage = request.TeacherMessage
                });
            }
            
        }
    }
}
