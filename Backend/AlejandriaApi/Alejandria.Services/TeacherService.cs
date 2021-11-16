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
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _repository;

        public TeacherService(ITeacherRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(TeacherDto entity)
        {
            try
            {
                await _repository.Create(new Teacher
                {
                    Institution = entity.Institution,
                    Name = entity.Name,
                    Img = entity.Img,
                    Description = entity.Description,
                    Course = entity.Course,
                    Rating = entity.Rating
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

        public async Task<ICollection<TeacherDto>> GetCollection(string filter)
        {
            var collection = await _repository.GetCollection(filter ?? string.Empty);

            return collection
                .Select(p => new TeacherDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Institution = p.Institution,
                    Img = p.Img,
                    Description = p.Description,
                    Course = p.Course,
                    Rating = p.Rating
                })
                .ToList();
        }

        public async Task<ResponseDto<TeacherDto>> GetTeacher(int id)
        {
            var response = new ResponseDto<TeacherDto>();
            var teacher = await _repository.GetItem(id);

            if (teacher == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new TeacherDto
            {
                Id = teacher.Id,
                Name = teacher.Name,
                Institution = teacher.Institution,
                Img = teacher.Img,
                Description = teacher.Description,
                Course = teacher.Course,
                Rating = teacher.Rating
            };

            response.Success = true;

            return response;
        }

        public async Task Update(int id, TeacherDto entity)
        {
            var teacher = await _repository.GetItem(id);

            if (teacher != null)
            {
                teacher.Name = entity.Name;
                teacher.Institution = entity.Institution;
                teacher.Img = entity.Img;
                teacher.Description = entity.Description;
                teacher.Course = entity.Course;
                teacher.Rating = entity.Rating;

                await _repository.Update(teacher);
            }
        }
    }
}
