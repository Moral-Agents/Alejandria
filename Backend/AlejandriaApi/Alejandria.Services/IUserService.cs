using Alejandria.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alejandria.Services
{
    public interface IUserService
    {
        ICollection<UserDto> GetCollection(string filter);

        UserDto GetUser(int id);

        void Create(UserDto entity);

        void Update(int id, UserDto entity);

        void Delete(int id);
    }
}
