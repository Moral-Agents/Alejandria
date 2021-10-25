using Alejandria.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alejandria.DataAccess
{
    public class RatingRepository : IRatingRepository
    {
        private readonly AlejandriaDbContext _context;

        public RatingRepository(AlejandriaDbContext context)
        {
            _context = context;
        }

        public async Task Create(Rating entity)
        {
            await _context.Set<Rating>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            _context.Entry(new Rating
            {
                Id = id
            }).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Rating>> GetCollection()
        {
            var collecion = await _context.Ratings
                .ToListAsync();

            return collecion;
        }

        public async Task<ICollection<Rating>> GetCollectionByCourseId(int courseId)
        {
            var collection = await _context.Ratings
                .Where(c => c.CourseId.Equals(courseId))
                .ToListAsync();

            return collection;
        }

        public async Task<Rating> GetItem(int id)
        {
            return await _context.Ratings.FindAsync(id);
        }

        public async Task Update(Rating entity)
        {
            _context.Set<Rating>().Attach(entity);
            await _context.SaveChangesAsync();
        }
    }
}
