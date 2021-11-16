using Alejandria.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alejandria.DataAccess
{
    public class CharacteristicRepository : ICharacteristicRepository
    {
        private readonly AlejandriaDbContext _context;

        public CharacteristicRepository(AlejandriaDbContext context)
        {
            _context = context;
        }

        public async Task Create(Characteristic entity)
        {
            await _context.Set<Characteristic>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            _context.Entry(new Characteristic
            {
                Id = id
            }).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task<Characteristic> GetItem(int id)
        {
            return await _context.Characteristics.FindAsync(id);
        }

        public async Task Update(Characteristic entity)
        {
            await _context.SaveChangesAsync();
        }
    }
}
