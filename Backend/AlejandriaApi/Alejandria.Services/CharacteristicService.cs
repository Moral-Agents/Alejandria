using Alejandria.DataAccess;
using Alejandria.Dtos;
using Alejandria.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alejandria.Services
{
    public class CharacteristicService : ICharacteristicService
    {
        private readonly ICharacteristicRepository _repository;

        public CharacteristicService(ICharacteristicRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(CharacteristicDto entity)
        {
            try
            {
                await _repository.Create(new Characteristic
                {
                    Atributo1 = entity.Characteristic1,
                    Atributo2 = entity.Characteristic2,
                    Atributo3 = entity.Characteristic3,
                    Atributo4 = entity.Characteristic4,
                    Atributo5 = entity.Characteristic5,
                    TeacherId = entity.TeacherId
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

        public async Task<ResponseDto<CharacteristicDto>> GetCharacteristic(int id)
        {
            var response = new ResponseDto<CharacteristicDto>();
            var characteristic = await _repository.GetItem(id);

            if (characteristic == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new CharacteristicDto
            {
                Id = characteristic.Id,
                Characteristic1 = characteristic.Atributo1,
                Characteristic2 = characteristic.Atributo2,
                Characteristic3 = characteristic.Atributo3,
                Characteristic4 = characteristic.Atributo4,
                Characteristic5 = characteristic.Atributo5,
                TeacherId = characteristic.TeacherId
            };

            response.Success = true;

            return response;
        }

        public async Task Update(int id, CharacteristicDto entity)
        {
            var characteristic = await _repository.GetItem(id);

            if (characteristic != null)
            {
                characteristic.Atributo1 = entity.Characteristic1;
                characteristic.Atributo2 = entity.Characteristic2;
                characteristic.Atributo3 = entity.Characteristic3;
                characteristic.Atributo4 = entity.Characteristic4;
                characteristic.Atributo5 = entity.Characteristic5;
                characteristic.TeacherId = entity.TeacherId;

                await _repository.Update(characteristic);
            }
        }
    }
}
