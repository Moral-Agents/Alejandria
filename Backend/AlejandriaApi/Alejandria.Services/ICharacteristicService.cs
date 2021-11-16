using Alejandria.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alejandria.Services
{
    public interface ICharacteristicService
    {
        Task<ResponseDto<CharacteristicDto>> GetCharacteristic(int id);

        Task Create(CharacteristicDto entity);

        Task Update(int id, CharacteristicDto entity);

        Task Delete(int id);
    }
}
