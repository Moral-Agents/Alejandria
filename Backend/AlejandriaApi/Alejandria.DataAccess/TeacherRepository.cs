using Alejandria.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alejandria.DataAccess
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly AlejandriaDbContext _context;

        public TeacherRepository(AlejandriaDbContext context)
        {
            _context = context;
        }

        public async Task Create(Teacher entity)
        {
            await _context.Set<Teacher>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            _context.Entry(new Teacher
            {
                Id = id
            }).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Teacher>> GetCollection(string filter)
        {
            var collection = await _context.Teachers
                .Where(c => c.Name.Contains(filter))
                .ToListAsync();

            return collection;
        }

        public async Task<Teacher> GetItem(int id)
        {
            return await _context.Teachers.FindAsync(id);
        }

        public async Task Update(Teacher entity)
        {
            _context.Set<Teacher>().Attach(entity);
            await _context.SaveChangesAsync();
        }
    }
}
