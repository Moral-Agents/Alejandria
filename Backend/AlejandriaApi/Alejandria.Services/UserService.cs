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
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(UserDto entity)
        {
            try
            {
                await _repository.Create(new User
                {
                    Email = entity.Email,
                    Password = entity.Password,
                    Role = entity.Role,
                    Institution = entity.Institution,
                    Name = entity.Name
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

        public async Task<ICollection<UserDto>> GetCollection(string filter)
        {
            var collection = await _repository.GetCollection(filter ?? string.Empty);

            return collection
                .Select(p => new UserDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Institution = p.Institution,
                    Role = p.Role,
                    Email = p.Email
                })
                .ToList();
        }

        public async Task<ResponseDto<UserDto>> GetUser(int id)
        {
            var response = new ResponseDto<UserDto>();
            var user = await _repository.GetItem(id);

            if (user == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Institution = user.Institution,
                Role = user.Role,
                Email = user.Email
            };

            response.Success = true;

            return response;
        }

        public async Task<ICollection<UserDto>> GetCollectionE(string email, string pwd)
        {
            var collection = await _repository.GetCollectionE(email, pwd);

            return collection
                .Select(p => new UserDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Institution = p.Institution,
                    Role = p.Role,
                    Email = p.Email
                })
                .ToList();
        }

        public async Task Update(int id, UserDto entity)
        {
            var user = await _repository.GetItem(id);

            if (user != null)
            {
                user.Name = entity.Name;
                user.Institution = entity.Institution;
                user.Role = entity.Role;
                user.Email = entity.Email;
                user.Password = entity.Password;

                await _repository.Update(user);
            }
        }
    }
}
