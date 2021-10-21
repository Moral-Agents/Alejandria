using Alejandria.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alejandria.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly AlejandriaDbContext _context;

        public UserRepository(AlejandriaDbContext context)
        {
            _context = context;
        }
        public async Task Create(User entity)
        {
            await _context.Set<User>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            _context.Entry(new User
            {
                Id = id
            }).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<User>> GetCollection(string filter)
        {
            var collection = await _context.Users
                .Where(c => c.Name.Contains(filter))
                .ToListAsync();

            return collection;
        }

        public async Task<User> GetItem(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task Update(User entity)
        {
            _context.Set<User>().Attach(entity);
            await _context.SaveChangesAsync();
        }
    }
}
