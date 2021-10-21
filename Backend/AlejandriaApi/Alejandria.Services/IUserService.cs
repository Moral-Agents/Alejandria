using Alejandria.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alejandria.Services
{
    public interface IUserService
    {
        Task<ICollection<UserDto>> GetCollection(string filter);

        Task<ResponseDto<UserDto>> GetUser(int id);

        Task Create(UserDto entity);

        Task Update(int id, UserDto entity);

        Task Delete(int id);
    }
}
