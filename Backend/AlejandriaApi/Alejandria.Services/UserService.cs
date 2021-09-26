using Alejandria.DataAccess;
using Alejandria.Dtos;
using Alejandria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alejandria.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public void Create(UserDto entity)
        {
            _repository.Create(new User
            {
                Email = entity.Email,
                Password = entity.Password,
                Role = entity.Role,
                Institution = entity.Institution,
                Name = entity.Name
            });
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public ICollection<UserDto> GetCollection(string filter)
        {
            var collection = _repository.GetCollection(filter ?? string.Empty);

            return collection
                .Select(c => new UserDto
                {
                    Id = c.Id,
                    Email = c.Email,
                    Password = c.Password,
                    Role = c.Role,
                    Institution = c.Institution,
                    Name = c.Name
                })
                .ToList();
        }

        public UserDto GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, UserDto entity)
        {
            _repository.Update(new User
            {
                Email = entity.Email,
                Password = entity.Password,
                Role = entity.Role,
                Institution = entity.Institution,
                Name = entity.Name
            });
        }
    }
}
