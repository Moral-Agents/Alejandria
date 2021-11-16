using Alejandria.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alejandria.DataAccess
{
    public interface ICharacteristicRepository
    {
        Task<Characteristic> GetItem(int id);

        Task Create(Characteristic entity);

        Task Update(Characteristic entity);

        Task Delete(int id);
    }
}
